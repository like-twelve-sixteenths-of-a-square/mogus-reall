using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MogusBurst : MonoBehaviour
{
    public GameObject mogus;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MogusBom());
    }

    IEnumerator MogusBom()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < Random.Range(5,9); i++) 
        {
            Instantiate (mogus, transform.position, transform.rotation);
        }
    }
}
