using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SpaceShipController
{

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if (GameManager.instance.gameOver)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            // Shot(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position));
            Shot();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
            //{
            //    Vector2 movement = new Vector2(horizontal, vertical) * Speed;
            //    rb2d.AddForce(movement);    
            //}
            Move(transform.position + new Vector3(horizontal, vertical), false);
    }

    public override void OnHit(int demage)
    {
        GameManager.instance.GameOver();
    }
}
