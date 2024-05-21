using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer line;
    private float lineEnd = 0;
    public float laserSpeed = 1;
    public float laserLength = 5;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineEnd += laserSpeed;
        float lineStart = Mathf.Max(0, lineEnd - laserLength);
        line.SetPosition(0, Vector3.forward * lineStart);
        line.SetPosition(1, Vector3.forward * lineEnd);
    }
}
