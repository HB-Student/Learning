using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int speed = 15;
    public double lifetime = 1;

    void Start()
    {
        transform.Rotate(0,0,Random.Range(-20, 20));
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        StartCoroutine(destroy());
    }

    IEnumerator destroy(){
        yield return new WaitForSeconds((float)lifetime);
        Destroy(gameObject);
    }
}
