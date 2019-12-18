using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class TestingFunctions : MonoBehaviour
{
    [MenuItem("TestingFunctions/RestPrefabs")]
    static void RestPrefabs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs Deleted");
    }
   
}
