using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject sprite;
    public GameObject bullet;
    public int speed = 8;
    public Vector3 mousePos = new Vector3();
    Vector3 targetPos = new Vector3();

    double cooldown = 0.5;
    float lastShot = 0f;
    int bullets = 20;

    void Start()
    {
        transform.up = transform.right;
        transform.Rotate(new Vector3(0, 0, 90));
    }

    void Update()
    {
        Vector3 WorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(WorldPoint.x, WorldPoint.y, 0);

        if (Vector2.Distance((Vector2)transform.position, (Vector2)targetPos) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

        if (Input.GetMouseButton(1))
        {
            MoveToMouse();
        }
        if (Input.GetKeyDown("q"))
        {
            Ability1();
        }
    }

    public void Ability1()
    {
        if (Time.time >= lastShot + cooldown)
        {
            lastShot = Time.time;
            for (int i = 0; i < bullets; i++)
            {
                GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity);
                clone.transform.rotation = sprite.transform.rotation;
            }
        }
    }

    void MoveToMouse()
    {
        sprite.GetComponent<playerSprite>().rotateSprite(targetPos);
        targetPos = mousePos;
    }
}