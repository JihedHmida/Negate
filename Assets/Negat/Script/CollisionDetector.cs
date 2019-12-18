using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision " + other.transform.name +" "+ other.gameObject.tag);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Goal"){
            Loader.Load(Loader.Scene.LevelScene);
        }
        Debug.Log("Trigger " + other.transform.name +" "+ other.tag);
    }
}
