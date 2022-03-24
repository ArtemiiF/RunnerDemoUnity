using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public List<GameObject> RoadPrefab;
    private List<GameObject> roads = new List<GameObject>();
    public float maxSpeed = 10;
    private float speed = 0;
    public int maxRoadCount = 5;
    bool flagStrtLvl = true;

    // Start is called before the first frame update
    void Start()
    {
        ResetLevel();
        // StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (speed == 0)
        {
            return;
        }
        foreach (GameObject road in roads)
        {
            road.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }

        if (roads[0].transform.position.z < -20)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);

            CreateNextRoad();
        }

    }

    public void StartLevel()
    {
        speed = maxSpeed;
        SwipeManager.instance.enabled = true;

        GameObject player = GameObject.Find("Player");
        player.GetComponent<PlayerAttributes>().isGoing = PlayerAttributes.IsGoing.Running;
        player.GetComponent<PlayerAttributes>().live = PlayerAttributes.Statement.Alive;
        player.GetComponent<AnimationControl>().StartRunAnim();
    }

    private void CreateNextRoad()
    {
        Vector3 pos = Vector3.zero;
        if (roads.Count > 0)
        {
            pos = roads[roads.Count - 1].transform.position + new Vector3(0, 0, 20);
        }
        if (flagStrtLvl)
        {
            GameObject go = Instantiate(RoadPrefab[0], pos, Quaternion.identity);
            go.transform.SetParent(transform);
            roads.Add(go);
            flagStrtLvl = !flagStrtLvl;
        }
        else
        {
            GameObject go = Instantiate(RoadPrefab[1], pos, Quaternion.identity);
            go.transform.SetParent(transform);
            roads.Add(go);
        }
    }

    public void ResetLevel()
    {
        Debug.Log("Level Reseted");

        flagStrtLvl = true;
        speed = 0;
        while (roads.Count > 0)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);
        }

        for (int i = 0; i < maxRoadCount; i++)
        {
            CreateNextRoad();
        }
        SwipeManager.instance.enabled = false;

        GameObject player = GameObject.Find("Player");
        player.GetComponent<PlayerMovement>().SetOnStartPos();

        GameObject GM = GameObject.Find("GameManager");
        GM.GetComponent<LevelUIControl>().StartGame();

        player.GetComponent<PlayerAttributes>().isGoing = PlayerAttributes.IsGoing.Idle;
        player.GetComponent<PlayerAttributes>().action = PlayerAttributes.Action.Idle;
        player.GetComponent<AnimationControl>().StartIdleAnim();
    }

    public void StopLevel()
    {
        speed = 0;
        GameObject player = GameObject.Find("Player");
        player.GetComponent<PlayerAttributes>().isGoing = PlayerAttributes.IsGoing.Idle;
        player.GetComponent<PlayerAttributes>().action = PlayerAttributes.Action.Idle;
        transform.position += new Vector3(0, 0, 1f);
    }
    public void ResumeLevel()
    {
        speed = maxSpeed;
    }
}

