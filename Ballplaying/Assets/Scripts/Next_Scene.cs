using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Next_Scene : MonoBehaviour {

    public void nextScene_BTN(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}