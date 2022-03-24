using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIControl : MonoBehaviour
{
    [SerializeField] GameObject UIInGame;
    [SerializeField] GameObject UIGameOver;
    [SerializeField] GameObject level;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        UIGameOver.SetActive(true);
        UIInGame.SetActive(false);
        level.GetComponent<RoadGenerator>().StopLevel();
    }

    public void StartGame()
    {
        UIGameOver.SetActive(false);
        UIInGame.SetActive(true);
    }

}
