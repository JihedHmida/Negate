using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            GamePlayManager.Instance.StartCameraSwitch();
            Destroy(this.gameObject);
        }
    }
}
