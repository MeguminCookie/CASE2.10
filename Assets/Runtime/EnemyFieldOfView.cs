using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFieldOfView : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float angle;

    [SerializeField] private GameObject playerRef;

    [SerializeField] private LayerMask targetMask;
    [SerializeField] private LayerMask obstructionMask;

    private bool canSeePlayer;
}
