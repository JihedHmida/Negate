using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Instance;
    public static bool is2D = true;
    public static bool isSwitching = false;


    public Animator CameraAnimatin;
    public Transform walls;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        CameraAnimatin = Camera.main.GetComponent<Animator>();
    }


    private void Update()
    {

        //Player.instance.StopMovement(CameraAnimatin.GetCurrentAnimatorStateInfo(0).IsName("AnimatedCameraMovement"));

    }

    public void StartCameraSwitch()
    {
        StartCoroutine(IE_Animation());
    }
    public void CameraSwitch()
    {
        Player.instance.StopMovement(true);
        Camera.main.orthographic = false;
        CameraAnimatin.Play("AnimatedCameraMovement");
        is2D = false;
        foreach (Transform item in walls)
        {
            item.GetComponent<BoxCollider>().material = null;
        }
    }

    IEnumerator IE_Animation()
    {
        CameraSwitch();

        while (!CameraAnimatin.GetCurrentAnimatorStateInfo(0).IsName("AnimatedCameraMovement"))
        {
            yield return null;
        }

        while ((CameraAnimatin.GetCurrentAnimatorStateInfo(0).normalizedTime) % 1 < 0.99f)
        {
            yield return null;
            Time.timeScale = 0;
        }

        Player.instance.StopMovement(false);
        Time.timeScale = 1;

    }
}
