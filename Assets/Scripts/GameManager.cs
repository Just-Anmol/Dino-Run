using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5.0f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    private PlayerContoller player;
    private Spawner spawner;



    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerContoller>();
        spawner = FindAnyObjectByType<Spawner>();

        NewGame();

        if(Instance == null)
        {
            Instance = this;
        }
        else 
            DestroyImmediate(gameObject);
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
    }

    void NewGame()
    {
        Obstacles[] obstacle = FindObjectsOfType<Obstacles>();
        
        foreach(var Obstacles in obstacle)
        {
            Destroy(Obstacles.gameObject);
        }

        gameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        gameSpeed = 0.0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);    
    }
}
