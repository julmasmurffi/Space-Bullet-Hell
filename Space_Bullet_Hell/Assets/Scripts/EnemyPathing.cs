﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    
    [SerializeField] List<Transform> waypoints = new List<Transform>();
    [SerializeField] float moveSpeed = 3f;
    int waypointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        //initial pos is the starting pos - go to pos 0
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PathToNext();
    }

    private void PathToNext()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPos = waypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, movementThisFrame);

            if(transform.position == targetPos)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
