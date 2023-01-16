using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    public void changeToScene(int scene){
        SceneManager.LoadScene(scene);
    }
}
