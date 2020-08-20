using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 3f;
    public int demage = 1;
    private string shooterTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShot(Vector2 direction, SpaceShipController shooter)
    {
        shooterTag = shooter.gameObject.tag;
        rb2d.AddForce(direction.normalized * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string collisionTag = collision.gameObject.tag;
        if ((collisionTag == "enemy" || collisionTag == "player") && shooterTag != collisionTag)
        {
            collision.gameObject.GetComponent<SpaceShipController>().OnHit(demage);
            Destroy(gameObject);
        }
        else if (collisionTag == "wall")
            Destroy(gameObject);
    }
}
