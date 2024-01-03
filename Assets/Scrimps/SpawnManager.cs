using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawn;
    void Start()
    {
        StartCoroutine(FunkyTown());
    }

    IEnumerator FunkyTown()
    {
        while (true) 
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            
            Instantiate (spawn, transform.position, transform.rotation);
        }
    }
}
