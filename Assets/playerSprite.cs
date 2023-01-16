using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSprite : MonoBehaviour
{
    public void rotateSprite(Vector3 targetPos){
        transform.up = targetPos - transform.position;
    }
    void start(){
    }
}
