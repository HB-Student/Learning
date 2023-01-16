using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	public GameObject bullet;
	public int speed = 8;
	Vector3 mousePos = new Vector3();
	
	double cooldown = 0.5;
	float lastShot = 0f;
	int bullets = 1; 

	
	void Update()
	{
		if (Input.GetMouseButton(1))
		{
			MoveToMouse();
		}
		if (transform.position != mousePos)
		{
			transform.position = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
		}

		if (Input.GetKeyDown("q"))
		{
			shoot();
		}
	}

    public void shoot()
    {
        if (Time.time >= lastShot + cooldown)
        {
            lastShot = Time.time;
            for (int i = 0; i < bullets; i++)
            {
                Instantiate(bullet, transform.position,Quaternion.identity);
            }
        }
    }

	void MoveToMouse()
	{
		Vector3 WorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos = new Vector3(WorldPoint.x, WorldPoint.y, 0);
	}
}