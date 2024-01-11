using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class mogusControl : MonoBehaviour
{
    public float vertiInput;
    public float horiInput;

    public float speed;
    public float turnSpeed;

    public GameObject shotLauncher;
    public GameObject normalProjectile;
    public GameObject burstProjectile;
    public GameObject blastProjectile;

    public Rigidbody rb;

    public float timeHeld;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vertiInput = Input.GetAxis("Vertical");
        horiInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * speed * Time.deltaTime * vertiInput);
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horiInput);

        //Catapult Shot
        if (Input.GetKey(KeyCode.J))
        {
            timeHeld += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            GameObject currentProjectile = Instantiate(normalProjectile, shotLauncher.transform.position, shotLauncher.transform.rotation);
            currentProjectile.GetComponent<mogusLob>().height = 2 * (1 + timeHeld);
            currentProjectile.GetComponent<mogusLob>().speed = 3 * (1 + timeHeld);

            timeHeld = 0;
        }

        //Scatter Shot
        if (Input.GetKey(KeyCode.K))
        {
            timeHeld += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            GameObject currentProjectile = Instantiate(burstProjectile, shotLauncher.transform.position, shotLauncher.transform.rotation);
            currentProjectile.GetComponent<mogusLob>().height = 3 * (1 + timeHeld);
            currentProjectile.GetComponent<mogusLob>().speed = 3 * (1 + timeHeld);

            timeHeld = 0;
        }

        //Mega Scatter Shot
        if (Input.GetKey(KeyCode.P))
        {
            timeHeld += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            GameObject currentProjectile = Instantiate(blastProjectile, shotLauncher.transform.position + new Vector3 (0, 1, 0), shotLauncher.transform.rotation);
            currentProjectile.GetComponent<mogusLob>().height = 1f * (1 + timeHeld);
            currentProjectile.GetComponent<mogusLob>().speed = 1f * (1 + timeHeld);

            timeHeld = 0;
        }

        //Snipe Shot
        if (Input.GetKey(KeyCode.L))
        {
            timeHeld += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            GameObject currentProjectile = Instantiate(normalProjectile, shotLauncher.transform.position, shotLauncher.transform.rotation);
            currentProjectile.GetComponent<mogusLob>().height = 0.5f * (1 + timeHeld);
            currentProjectile.GetComponent<mogusLob>().speed = 7.5f * (1 + timeHeld);

            timeHeld = 0;
        }

        //Spam
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameObject currentProjectile = Instantiate(normalProjectile, shotLauncher.transform.position, shotLauncher.transform.rotation);
            currentProjectile.GetComponent<mogusLob>().height = 5;
            currentProjectile.GetComponent<mogusLob>().speed = 10;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Baddie"))
        {
            Debug.Log("Game Over");

            rb.AddForce(Vector3.up * 1250, ForceMode.Impulse);
        }
    }
}
