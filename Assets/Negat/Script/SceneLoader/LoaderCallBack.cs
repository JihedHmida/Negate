using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallBack : MonoBehaviour
{
    bool isFirstUpdate = true;
    float timeLeft = 0f;


    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            if (isFirstUpdate)
            {
                isFirstUpdate = false;
                Loader.LoaderCallBack();
            }
        }


    }

}
