using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;
    public float[] XRandomRange = new float[2];
    public float[] YRandomRange = new float[2];
    public GameObject[] enemys;
    public GameObject EnemyRoot;
    private int level;
    // millisecond
    private float levelTime;
    public float refreshEnemyInterval;
    private float refreshEnemyDuration;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void InitLevel(int level)
    {
        this.level = level;
        levelTime = 60;
    }


    // Update is called once per frame
    void Update()
    {
        levelTime -= Time.deltaTime;
        if (levelTime <= 0)
        {
            GameManager.instance.GameOver();
        }
        refreshEnemyDuration += Time.deltaTime;
        if (refreshEnemyDuration >= refreshEnemyInterval)
        {
            GenerateEnemy();
            refreshEnemyDuration -= refreshEnemyInterval;
        }
    }

    private void GenerateEnemy()
    {
        GameObject enemy = Instantiate(enemys[Random.Range(0, enemys.Length)]);
        enemy.transform.SetParent(EnemyRoot.transform);
        enemy.transform.position = new Vector3(Random.Range(XRandomRange[0], XRandomRange[1]), Random.Range(YRandomRange[0], YRandomRange[1]), 0);
     
    }
}
