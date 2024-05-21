using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody body;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(0, ver, hor);
        move.Normalize();
        body.AddRelativeForce(move * speed);
        body.AddRelativeForce(-body.velocity);
    }
}