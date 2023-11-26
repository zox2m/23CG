using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text gameOverText;
    public Button restartButton;
    public Button quitButton;

    void Start()
    {
        // 게임 오버 UI 초기화
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);

        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);

        if (quitButton != null)
            quitButton.onClick.AddListener(QuitGame);
    }

    void RestartGame()
    {
        // 재시작 버튼 클릭 시 실행할 동작
        // 여기에서는 현재 씬을 다시 로드하는 것으로 가정합니다.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void QuitGame()
    {
        // 나가기 버튼 클릭 시 실행할 동작
        // 여기에서는 게임을 종료하는 것으로 가정합니다.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ShowGameOverUI()
    {
        // 게임 오버 UI를 활성화
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(true);
    }
}
