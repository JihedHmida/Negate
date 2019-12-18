using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type : MonoBehaviour
{
    public GoType  goType ;
    public enum GoType{
        Laser,
        FireBall,
        MovingEnemy,
        Platform,
        Goal,
        CameraTrigger,
        Star
    }
}
