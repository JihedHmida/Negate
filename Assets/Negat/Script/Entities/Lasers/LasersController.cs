using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System;
using UnityEngine;

public class LasersController : MonoBehaviour
{
    public GameObject FirePoint;
    public GameObject[] Prefabs;
    public Transform endPoint;
    public int Prefab;
    private GameObject Instance;
    private Laser LaserScript;
    private Vector3 LaserEndPoint;
    public int scale;


    private float _elapsedTime = 0.0f;
    bool shooting = true;
    public float shootingTime;
    public float timeToTheNextShoot;
    public float currentTimeToTheNextShot;

    Light laserLight;

    private void Awake()
    {
        laserLight = GetComponent<Light>();
        laserLight.enabled = false;
    }

    void Start()
    {
        _elapsedTime = UnityEngine.Random.Range(0, 2);

        SetTimer();
        Invoke("StartIE_ShootTimer", _elapsedTime);

        FirePoint = this.gameObject;
        LaserEndPoint = endPoint.position;
    }


    void Update()
    {
        //Debug.Log(PercentageToTheNextShot());

        LightControl();
    }
    void StartIE_ShootTimer()
    {
        StartCoroutine(IE_ShootTimer());
    }
    IEnumerator IE_ShootTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootingTime);
            ShootTimer();
            SetTimer();
        }
    }

    void SetTimer()
    {
        shootingTime = UnityEngine.Random.Range(1f, 4f);
        timeToTheNextShoot = shootingTime + Time.deltaTime;
        currentTimeToTheNextShot = timeToTheNextShoot;
    }

    void LightControl()
    {
        if (!shooting) return;

        currentTimeToTheNextShot -= Time.deltaTime;
        if (currentTimeToTheNextShot <= .5f)
        {
            laserLight.enabled = true;
        }
        else
        {
            laserLight.enabled = false;
        }

    }
    public float PercentageToTheNextShot()
    {
        if (shooting)
        {
            currentTimeToTheNextShot -= Time.deltaTime;
            return (Mathf.Lerp(1, 0, currentTimeToTheNextShot / timeToTheNextShoot));
        }
        return 1;
    }

    void ShootTimer()
    {
        if (shooting)
        {
            laserLight.enabled = false;
            shooting = false;
            ShootLaser();
        }
        else
        {
            shooting = true;
            DestoryLaser();

        }
    }


    void DestoryLaser()
    {
        LaserScript.DisablePrepare();
        Destroy(Instance, 1);
    }
    void ShootLaser()
    {
        Destroy(Instance);
        Instance = Instantiate(Prefabs[Prefab], FirePoint.transform.position, FirePoint.transform.rotation);

        CapsuleCollider collider = Instance.GetComponentInChildren<CapsuleCollider>();
        collider.transform.LookAt(FirePoint.transform);
        float height = (LaserEndPoint - FirePoint.transform.position).magnitude;
        collider.height = height;
        collider.direction = 2;
        collider.center = new Vector3(0, 0, 0);

        Instance.transform.localScale = new Vector3(scale, scale, scale);
        Instance.transform.LookAt(endPoint.position);
        Instance.transform.parent = transform;
        LaserScript = Instance.GetComponent<Laser>();
    }



    void Counter(int count)
    {
        Prefab += count;
        if (Prefab > Prefabs.Length - 1)
        {
            Prefab = 0;
        }
        else if (Prefab < 0)
        {
            Prefab = Prefabs.Length - 1;
        }
    }

}
