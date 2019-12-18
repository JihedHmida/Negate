using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag != "Player" && other.transform.tag != "Ground")
        {
            Debug.Log("xx");
            Destroy(other.transform.parent.gameObject);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "Player" && other.transform.tag != "Ground")
        {
            Debug.Log("xx");

            Destroy(other.transform.parent.gameObject);
        }
    }
}
