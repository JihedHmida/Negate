using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void Awake()
    {
        if (GamePlayManager.is2D)
        {
            Camera.main.orthographic = true;
        }
    }

    private void LateUpdate()
    {
        if (player)
        {
            if (this.transform.position.y > player.transform.position.y)
            {

                this.transform.position = new Vector3(0, player.transform.position.y, 0f);
                
                /*if (GamePlayManager.is2D)
                {
                    this.transform.position = new Vector3(0, player.transform.position.y, 0f);
                }
                else
                {
                    this.transform.position = new Vector3(0, player.transform.position.y, 0);
                }*/
            };
        }
    }

}
