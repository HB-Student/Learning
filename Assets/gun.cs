using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    Transform p;
    public GameObject bullet;
    Vector3 pastPlayerPos = new Vector3();
    Vector3 pastMousePos = new Vector3(0, 1, 0);
    Vector3 mousePos = new Vector3();
    public double cooldown = 0.2;

    float angle;

    bool primaryCooldown = false;

    void Start()
    {
        p = transform.parent;
    }

    void Update()
    {
        moveToPlayer();
        rotateGun();

        if (Input.GetMouseButton(0))
        {
            StartCoroutine(primaryFire());
        }
    }

    void rotateGun()
    {
        mousePos = p.GetComponent<player>().mousePos;
        Vector2 vec1 = (Vector2)mousePos - (Vector2)p.position;
        Vector2 vec2 = (Vector2)pastMousePos - (Vector2)pastPlayerPos;
        angle = Vector2.Angle(vec1, vec2);
        Vector3 cross = Vector3.Cross(vec1, vec2);
        if (cross.z > 0) angle = -angle;
        transform.RotateAround(p.position, Vector3.forward, angle);
        pastMousePos = mousePos;
        pastPlayerPos = p.position;
    }

    void moveToPlayer()
    {
        transform.position = p.position + transform.up;
    }

    IEnumerator primaryFire()
    {
        if (!primaryCooldown)
        {
            if (Vector2.Distance((Vector2)mousePos, (Vector2)p.position) > p.localScale.x+transform.localScale.y)
            {
                primaryCooldown = true;
                Vector2 direction = ((Vector2)mousePos - (Vector2)transform.position).normalized;
                GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity);
                clone.transform.up = direction;
                yield return new WaitForSeconds(((float)cooldown));
                primaryCooldown = false;
            }
        }
    }
}
