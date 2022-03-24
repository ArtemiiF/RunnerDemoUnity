using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject player;

    public float timeForAttack;
    bool flagStartAttack = false;


    // Start is called before the first frame update
    void Start()
    {
        SwipeManager.instance.MoveEvent += Attack;
    }

    //Timer with stopping attack
    IEnumerator Timer(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);

        player.GetComponent<PlayerAttributes>().action = PlayerAttributes.Action.Idle;
        Debug.Log("Player stop attacking");
        GetComponent<AnimationControl>().StopAttack();
        flagStartAttack = false;
    }

    private void Attack(bool[] swipes)
    {
        if (swipes[2] && (player.GetComponent<PlayerAttributes>().live == PlayerAttributes.Statement.Alive))
        {
            if (!flagStartAttack)
            {
                Debug.Log("Player Attacked");
                flagStartAttack = true;

                player.GetComponent<PlayerAttributes>().action = PlayerAttributes.Action.Attack;
                GetComponent<AnimationControl>().StartAttack();
                StartCoroutine(Timer(timeForAttack));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}
