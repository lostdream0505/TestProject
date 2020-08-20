using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;
    public static GameManager instance;
    public GameObject player = null;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LevelManager.instance.InitLevel(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int score)
    {
        this.score += score;
        // update view
    }

    public void GameOver()
    {
        if (!gameOver)
        {
            Destroy(player);
            gameOver = true;
        }
    }


    public Vector3 GetPlayerPosition()
    {
        return player.transform.position;
    }
}
