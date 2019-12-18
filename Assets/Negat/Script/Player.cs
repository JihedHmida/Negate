using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player instance;

    Rigidbody rb;
    [SerializeField] float force = 5;
    [SerializeField] float maxVelocity = 5;
    [SerializeField] bool allMovementStopped;
    private void Awake()
    {
        if (!instance)
            instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!allMovementStopped)
        {

            #if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                if (GamePlayManager.is2D)
                {
                    Controll2d(Input.mousePosition.x);
                }
                else
                {
                    Controll3d(Input.mousePosition.x);
                }
            }
            #endif
            if (Input.touchCount > 0)
            {
                if (GamePlayManager.is2D)
                {
                    Controll2d(Input.touches[0].position.x);
                }
                else
                {
                    Controll3d(Input.touches[0].position.x);
                }
            }

        }
    
    
    }

    void Controll2d(float xPosition)
    {

        // maxVelocity = 20;
        if (xPosition < Screen.width / 2)
        {
            rb.velocity = new Vector3(1, 1, 0) * force;
            //Debug.Log("Left click");
            //Debug.DrawLine(this.transform.position, new Vector2(1, 1));
        }
        if (xPosition > Screen.width / 2)
        {
            rb.velocity = new Vector3(-1, 1, 0) * force;
            //Debug.Log("Right click");
            //Debug.DrawLine(this.transform.position, new Vector2(-1, 1));
        }

    }

    void Controll3d(float xPosition)
    {
        // maxVelocity = 20;
        if (xPosition < Screen.width / 2)
        {
            rb.velocity = new Vector3(1, rb.velocity.y / force, 0) * force;
            //Debug.Log("Left click");
            //Debug.DrawLine(this.transform.position, new Vector2(1, 0));
        }
        if (xPosition > Screen.width / 2)
        {
            rb.velocity = new Vector3(-1, rb.velocity.y / force, 0) * force;
            //Debug.Log("Right click");
            //Debug.DrawLine(this.transform.position, new Vector2(-1, 0));
        }
    }



    public void StopMovement(bool state)
    {
        this.rb.isKinematic = state;
        allMovementStopped = state;
    }
    void FixedUpdate()
    {

        ClampVelocity(maxVelocity);

    }


    void ClampVelocity(float maxVelocity)
    {
        if (rb.velocity.sqrMagnitude > maxVelocity * maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }
}
