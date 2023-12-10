using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneMove : MonoBehaviour
{
    public void GameSceneCtrl()
    {
        SceneManager.LoadScene("Scene_01");
        Debug.Log("Game Scene go");
    }

}
