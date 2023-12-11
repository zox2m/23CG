using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using SojaExiles;

public class GameManager : MonoBehaviour
{
    public float gameTimeLimit = 600.0f; // 제한 시간 (10분 = 600초)
    public float currentTime = 0.0f;
    public bool isGameOver = false;
    
    //public PrefabManager PrefabManager;
    //public ItemManager ItemManager;
    public GameObject CoverImage;
    public GameObject player;
    public Camera camera;
    public Text timerText; // UI에 남은 시간을 표시할 텍스트
    public GameObject gameOverUI; // 게임 오버 UI

    public GameObject gameClearUI; // 게임 성공 UI

    public static GameManager instance = null;

    private void Awake()
    {
        if (null == instance)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            //씬 전환이 되더라도 파괴되지 않게 한다.
            //gameObject만으로도 이 스크립트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만, 
            //나는 헷갈림 방지를 위해 this를 붙여주기도 한다.
            DontDestroyOnLoad(this.gameObject);
        }else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr이 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 GameMgr)을 삭제해준다.
            Destroy(this.gameObject);
        }

        currentTime = gameTimeLimit;
        UpdateTimerText();

        // 초기에는 게임 오버 UI 비활성화
        if (gameOverUI != null)
            gameOverUI.SetActive(false);

        if (gameClearUI != null)
            gameClearUI.SetActive(false);
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
            //Debug.Log("Current Time: " + currentTime);
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

        //움직임 멈추기 
        //player.GetComponent<PlayerMovement>().enable = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        camera.GetComponent<MouseLook>().enabled = false;
    }

    public void GameClear()
    {
        isGameOver = true;

        // 현관문 열면 성공 UI 활성화
        if (gameClearUI != null)
            gameClearUI.SetActive(true);

        // 시간을 멈추기
        Time.timeScale = 1f;
        ObjectClicker.uiIsActived = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //움직임 멈추기 
        player.GetComponent<PlayerMovement>().enabled = false;
        camera.GetComponent<MouseLook>().enabled = false;
    }
}
