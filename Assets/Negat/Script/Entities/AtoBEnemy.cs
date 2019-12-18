using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtoBEnemy : MonoBehaviour
{
    public static int graphicIndex = 50;

    public int index;
    [SerializeField] Transform[] pathPoints = new Transform[2];
    [SerializeField] public Transform enemyObj;
    [SerializeField] float movementSpeed = 3;
    [SerializeField] float rotationSpeed = 90;

    private int currentTargetIndex;
    private float distance;
    private Vector3 direction;
    private void Awake()
    {
        if (graphicIndex > enemyObj.childCount-1)
        {
            graphicIndex = Random.Range(0, enemyObj.childCount-1);
        }
    }

    private void Start()
    {
        currentTargetIndex = Random.Range(0, pathPoints.Length);
        this.enemyObj.position = pathPoints[currentTargetIndex].position;
        enemyObj.GetChild(graphicIndex).gameObject.SetActive(true);
    }
    private void Update()
    {

        Move();
        //Rotate();


    }

    public void Index()
    {
        index++;
    }
    public int GetIndex()
    {
        return index;
    }


    void Move()
    {
        distance = Vector3.Distance(this.enemyObj.position, pathPoints[currentTargetIndex].position);
        if (distance > .1f)
        {
            direction = pathPoints[currentTargetIndex].position - enemyObj.position;
            enemyObj.position = this.enemyObj.position + direction.normalized * Time.deltaTime * movementSpeed;

        }
        else
        {
            ChangeTarget();
        }

    }
    void ChangeTarget()
    {
        currentTargetIndex++;
        if (currentTargetIndex >= pathPoints.Length)
        {
            currentTargetIndex = 0;
        }
    }

    void Rotate()
    {
        this.enemyObj.transform.eulerAngles += Vector3.forward * Time.deltaTime * rotationSpeed;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(pathPoints[0].position, .25f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(pathPoints[1].position, .25f);

    }
}
