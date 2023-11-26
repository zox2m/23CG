using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{
    public float LimitTime;
    public Text text_Timer;

    void Update()
    {
        LimitTime -= Timer.deltaTime;
        text_Timer.text = "시간 : " + Mathf.Round(LimitTime);
    }
}
