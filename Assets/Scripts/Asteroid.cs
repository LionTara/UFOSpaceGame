using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody body;
    public GameObject explosion;

    public float asteroidSpeed = 1.5f;
    public float asteroidAngularSpeed = 1;
    public float minSize = 0.5f;
    public float maxSize = 8f;
    public float size;

    // Start is called before the first frame update
    void Start()
    {
        size = Random.Range(minSize, maxSize);

        transform.localScale *= size;

        body = GetComponent<Rigidbody>();

        float forceMagnitude = asteroidSpeed / size;
        Vector3 forceDirection = Vector3.right;
        body.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);

        body.angularVelocity = Random.onUnitSphere * asteroidAngularSpeed / size;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            //if (gameObject.name.Contains("Asteroid"))
            //{
                Explode();
                PlayerHP playerHP =other.gameObject.GetComponent<PlayerHP>();
                playerHP.Damage(Mathf.RoundToInt(size * 10));
                //print("Asteroid Hit!");
            //}
        }

        else if (other.gameObject.name.Contains("Asteroid"))
        {
            Asteroid otherAsteroid = other.gameObject.GetComponent<Asteroid>();
            if (size < otherAsteroid.size)
            {
                Destroy(gameObject);
                //print("Asteroid Destroy!");

            }
        }
    }

    public void Explode()
    {
        GameObject expl = Instantiate(explosion, transform.position, transform.rotation);
        expl.transform.localScale *= size;
        Destroy(expl, 1f);
        Destroy(gameObject);
        print("2");

    }
}
