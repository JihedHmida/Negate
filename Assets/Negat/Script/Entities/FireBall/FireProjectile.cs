using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;


public class FireProjectile : MonoBehaviour
{

    public float followSpeed = 5;
    public float muzzleSpeed = 100;
    public float range = 5;
    public float followingDuration;

    public GameObject[] projectiles;
    [HideInInspector]
    public int currentProjectile = 0;
    public GameObject idle;
    Transform target;
    GameObject projectile;
    float _duration;
    bool following;
    bool lost;

    Vector3 targetLast;
    private void Start()
    {
        _duration = followingDuration;
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
        CheckDistance();
        CountDown();
    }
    void CheckDistance()
    {
        if (!target) return;
        if (following) return;

        if (Vector3.Distance(this.transform.position, target.position) < range)
        {
            _duration += Time.deltaTime;
            following = true;
            Shoot();
        }
    }
    void CountDown()
    {
        if (!following && !lost) return;
        if (following)
        {
            FollowTarget();
            _duration -= Time.deltaTime;
            if (0 >= _duration)
            {
                LeaveTarget();
                lost = true;
                following = false;
                _duration = followingDuration;
                _duration += Time.deltaTime;

            }
        }
        if (lost)
        {
            _duration -= Time.deltaTime;
            if (0 >= _duration)
            {
                Expload();
                Destroy(this.transform.parent.gameObject);
            }
        }
    }

    public void Shoot()
    {
        idle.SetActive(false);
        projectile = Instantiate(projectiles[currentProjectile], this.transform.position, Quaternion.identity) as GameObject;
        projectile.transform.localScale = new Vector3(.5f, .5f, .5f);
        projectile.transform.LookAt(target.position);
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * muzzleSpeed);
        projectile.GetComponent<ProjectileScript>().impactNormal = target.position;
    }

    public void FollowTarget()
    {
        if(!projectile){
            Destroy(this.transform.parent.gameObject,.5f);
        }
        if (target && projectile)
        {
            projectile.transform.LookAt(target.position);
            projectile.transform.position = Vector3.MoveTowards(projectile.transform.position, target.position, followSpeed * Time.deltaTime);
        }
    }
    public void LeaveTarget()
    {
        if (target)
        {
            targetLast = target.position;
            projectile.GetComponent<Rigidbody>().velocity = targetLast;
            target = null;
        }
    }
    public void Expload()
    {
        if (projectile)
        {
            projectile.GetComponent<ProjectileScript>().Boom();
        }
    }












}
