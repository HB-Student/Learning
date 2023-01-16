using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eye : MonoBehaviour
{
    Transform p;

    void Start()
    {
        p = transform.parent.parent;
    }

    void Update()
    {
        Vector3 mousePos = p.GetComponent<player>().mousePos;
        Vector2 direction = ((Vector2)mousePos - (Vector2)transform.position).normalized;
        transform.up = direction;
    }
}
