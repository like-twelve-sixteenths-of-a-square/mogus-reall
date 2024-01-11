using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class guyMove : MonoBehaviour
{
    public float speed;

    public GameObject point;
    public GameObject pointSpot;
    void Start()
    {
        pointSpot = GameObject.Find("PointSpot");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.y < -3)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mogus"))
        {
            Instantiate(point, pointSpot.transform.position, pointSpot.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
