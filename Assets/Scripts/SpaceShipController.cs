using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    public GameObject bullet;
    public float shootCoolDown;
    public float Speed = 3f;
    public Rigidbody2D rb2d;

    protected bool canShot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    protected void Move(Vector3 end, bool needRotate = true)
    {
        if (needRotate)
            transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, (end - transform.position)));
        Vector3 newPosition = Vector3.MoveTowards(rb2d.position, end, Speed * Time.deltaTime);
        rb2d.MovePosition(newPosition);
    }

    protected void Shot()
    {
        if (!canShot)
            return;
        // rotate space ship
        //float angle = Vector2.SignedAngle(Vector2.up, direction);
        float angle = transform.eulerAngles.z;
        //transform.rotation = Quaternion.Euler(0, 0, angle);
        GameObject bullet = Instantiate(this.bullet);
        float x = Mathf.Sin(-angle * Mathf.Deg2Rad) * 0.75f;
        float y = Mathf.Cos(-angle * Mathf.Deg2Rad) * 0.75f;
        Vector3 offset = new Vector3(x, y, 0);
        Debug.Log(offset);
        bullet.transform.position = transform.position + offset;
        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<Bullet>().OnShot(offset, this);
        canShot = false;
        Invoke(nameof(Reload), shootCoolDown);
    }


    public virtual void OnHit(int demage)
    {

    }

    protected void OnDeath()
    {

    }
    protected void Reload()
    {
        canShot = true;
    }
}
