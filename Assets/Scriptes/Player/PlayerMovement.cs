using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed,
                 deltaLanes,
                zeroLanePos;
    int currLane = 1;


    Vector3 startingPos;
    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        SwipeManager.instance.MoveEvent += Move;
        startingPos = transform.position;
        targetPos = startingPos;
    }

    private void Move(bool[] swipes)
    {
        if (GetComponent<PlayerAttributes>().live==PlayerAttributes.Statement.Alive)
        {
            if (swipes[0] && (currLane > 0))
            {
                Debug.Log("Left Movement");
                currLane--;
                targetPos += new Vector3(-deltaLanes, 0);

            }
            else if (swipes[1] && (currLane < 2))
            {
                Debug.Log("Right Movement");
                currLane++;
                targetPos += new Vector3(deltaLanes, 0);
            }
        }
        
    }

    public void SetOnStartPos()
    {
        transform.position = startingPos;
        targetPos = startingPos;
        currLane = 1;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }


}
