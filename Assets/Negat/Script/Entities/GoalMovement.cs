using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMovement : MonoBehaviour
{
    public int count;
    public int index;
    [SerializeField] Vector3[] pathPoints = new Vector3[2];
    [SerializeField] float MinX = -3.5f;
    [SerializeField] float MaxX = 3.5f;

    [SerializeField] public Transform goal;
    [SerializeField] float movementSpeed = 3;

    private int currentTargetIndex;
    private float distance;
    private Vector3 direction;
    private void Awake()
    {
        for (int i = 0; i < pathPoints.Length; i++)
        {
            pathPoints[i] = this.transform.position;
        }
        pathPoints[0].x = MinX;
        pathPoints[1].x = MaxX;
    }
    public void Index()
    {
        count++;
        index = count;
    }
    public int GetIndex()
    {
        return index;
    }
    private void Update()
    {
        Move();
    }


    void Move()
    {
        distance = Vector3.Distance(this.goal.position, pathPoints[currentTargetIndex]);
        if (distance > .1f)
        {
            direction = pathPoints[currentTargetIndex] - goal.position;
            goal.position = this.goal.position + direction.normalized * Time.deltaTime * movementSpeed;

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


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(pathPoints[0], .25f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(pathPoints[1], .25f);

    }


}
