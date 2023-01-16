using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class primaryAttack : MonoBehaviour
{
    public int speed = 15;

    void Start()
    {

    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
