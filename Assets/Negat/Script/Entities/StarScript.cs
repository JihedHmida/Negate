using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject pickUp;

    public Transform graphic;
    void Start()
    {

    }

    void Update()
    {
        this.transform.eulerAngles += new Vector3(0, rotationSpeed, 0) * Time.deltaTime;
    }

    void PickUpStar()
    {
        Destroy(graphic.gameObject);
        Instantiate(pickUp, this.transform.position, Quaternion.identity, this.transform);
        Destroy(this.gameObject,1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PickUpStar();
        }
    }
}
