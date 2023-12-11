using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgress : MonoBehaviour
{
    public Text ProgressIndicator;
    public Image LoadingBar;

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
        //남은 시간이 0이 되면.. 
        if (gameManager.currentTime == 0)
        {
            ProgressIndicator.text = "Done";
            
            // 게임이 완료되면 GameManager의 GameOver 함수 호출
            if (gameManager != null)
                gameManager.GameOver();
        }
        //남은 시간 비율로 보여주기 
        LoadingBar.fillAmount = gameManager.currentTime / gameManager.gameTimeLimit;
    }
}
