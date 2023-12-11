using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgress : MonoBehaviour
{
    public Text ProgressIndicator;
    public Image LoadingBar;


    // Update is called once per frame
    void Update()
    {
        //남은 시간이 0이 되면.. 
        if (GameManager.instance.currentTime == 0)
        {
            ProgressIndicator.text = "Done";
            GameManager.instance.GameOver();
        }
        //남은 시간 비율로 보여주기 
        LoadingBar.fillAmount = GameManager.instance.currentTime / GameManager.instance.gameTimeLimit;
    }
}
