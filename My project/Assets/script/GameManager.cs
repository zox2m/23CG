using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public float gameTimeLimit = 600.0f; // 제한 시간 (10분 = 600초)
    private float currentTime = 0.0f;
    private bool isGameOver = false;
    
    //public PrefabManager PrefabManager;
    //public ItemManager ItemManager;
    public GameObject CoverImage;

    public Text timerText; // UI에 남은 시간을 표시할 텍스트
    public GameObject gameOverUI; // 게임 오버 UI

    private void Start()
    {
        
        currentTime = gameTimeLimit;
        UpdateTimerText();

        // 초기에는 게임 오버 UI 비활성화
        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }

    public void OnClickStartButton()
    {
        CoverImage.SetActive(false);
    }
    
    private void Update()
    {
        if (!isGameOver)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
                GameOver();
            }

            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            // Debug.Log로 현재 시간을 콘솔에 출력
            Debug.Log("Current Time: " + currentTime);
        }
    }

    public void GameOver()
    {
        isGameOver = true;

        // 시간 초과 시 게임 오버 UI 활성화
        if (gameOverUI != null)
            gameOverUI.SetActive(true);

        // 시간을 멈추기
        Time.timeScale = 1f;
        ObjectClicker.uiIsActived = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
