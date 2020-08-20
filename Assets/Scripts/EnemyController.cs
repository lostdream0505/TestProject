using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SpaceShipController
{
    public int score;
    public int health;
    private bool initFinish;

    private void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        float brakeTime = 0;
        while (brakeTime < 1)
        {
            brakeTime += Time.deltaTime;
            GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, brakeTime);
            yield return null;
        }
        GetComponent<BoxCollider2D>().enabled = true;
        initFinish = true;
        yield return null;
    }

    private void FixedUpdate()
    {
        if (!initFinish || GameManager.instance.gameOver)
            return;
        // 进入到玩家一定范围后不继续移动
        if (Vector2.Distance(GameManager.instance.GetPlayerPosition(), transform.position) <= 5)
            return;
        Vector3 playerPosition = GameManager.instance.GetPlayerPosition();
        Move(playerPosition);
        //Shot(playerPosition - transform.position);
        Shot();
    }

    public override void OnHit(int demage)
    {
        // play hit effect
        health -= demage;
        if (health <= 0)
            OnDeath();
    }

    protected new void OnDeath()
    {
        GameManager.instance.AddScore(score);
        // play death effect
        Destroy(gameObject);
    }

}
