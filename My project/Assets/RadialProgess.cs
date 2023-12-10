using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgress : MonoBehaviour
{
    public Text ProgressIndicator;
    public Image LoadingBar;
    float currentValue;
    public float speed = 100;

    // GameManager 인스턴스를 저장할 변수
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentValue < 100)
        {
            currentValue += speed * Time.deltaTime;
            ProgressIndicator.text = ((int)currentValue).ToString() + "%";
        }
        else
        {
            ProgressIndicator.text = "Done";
            
            // 게임이 완료되면 GameManager의 GameOver 함수 호출
            if (gameManager != null)
                gameManager.GameOver();
        }

        LoadingBar.fillAmount = currentValue / 100;
    }
}
