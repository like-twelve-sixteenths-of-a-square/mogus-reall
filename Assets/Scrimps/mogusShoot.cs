using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mogusShoot : MonoBehaviour
{
    public float delay;

    public float speed;
    void Start()
    {
        Destroy(gameObject, delay);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
