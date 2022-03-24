using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject UIController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroyable"))
        {
            Debug.Log("Player Collision with destroyable object");
            if (player.GetComponent<PlayerAttributes>().action==PlayerAttributes.Action.Attack)
            {
                Debug.Log("Player destroy obj");
                Destroy(other.gameObject);
                
            }
            else
            {
                Debug.Log("Player dead");
                player.GetComponent<AnimationControl>().StartDead();
                player.GetComponent<PlayerAttributes>().live = PlayerAttributes.Statement.Dead;
                UIController.GetComponent<LevelUIControl>().GameOver();
            }
        }
        else if (other.gameObject.CompareTag("Undestroyable"))
        {
            Debug.Log("Player Collision with undestroyable object");
            Debug.Log("Player dead");
            player.GetComponent<AnimationControl>().StartDead();
            player.GetComponent<PlayerAttributes>().live = PlayerAttributes.Statement.Dead;
            UIController.GetComponent<LevelUIControl>().GameOver();
        }
        else 
        {
            Debug.Log("Player Collision with smth");
        }
    }
}
