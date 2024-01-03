using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mogusLob : MonoBehaviour
{
    public float delay;

    public Rigidbody body;

    public float height;
    public float speed;

    void Start()
    {
        Destroy(gameObject, delay);
        body = GetComponent<Rigidbody>();

        body.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        body.AddRelativeForce(Vector3.up * height, ForceMode.Impulse);
        body.AddRelativeTorque(Vector3.right * 720);
    }


    void Update()
    {
    }
}
