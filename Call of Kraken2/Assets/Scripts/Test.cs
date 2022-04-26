using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
           // Instantiate(cannon, transform.position, transform.rotation);
 

            yield return new WaitForSeconds(Random.Range(0.1f, 1f));
        }
    }
}
