using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space")){
            Vector3 playerPos = player.transform.position;
            transform.position = new Vector3 (playerPos.x,playerPos.y,transform.position.z);
        }
    }
}
