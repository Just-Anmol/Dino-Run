using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5.0f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    private PlayerContoller player;
    private Spawner spawner;

    public TextMeshProUGUI gameOver;
    public Button retryButton;



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

    public void NewGame()
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

        gameOver.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameSpeed = 0.0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);

        gameOver.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
    }
}
