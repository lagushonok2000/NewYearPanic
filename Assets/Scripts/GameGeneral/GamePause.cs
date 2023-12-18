using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _stopPauseButton;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _mainMenuButton;

    private void Start()
    {
        _pauseButton.onClick.AddListener(PauseButton);
        _stopPauseButton.onClick.AddListener(StopPauseButton);
        _mainMenuButton.onClick.AddListener(ExitToMainMenu);
    }

    public void ExitToMainMenu()
    {
        SaveGame.Data.CurrentIndexScene = SceneManager.GetActiveScene().buildIndex;
        SaveGame.SaveData();
        SceneManager.LoadScene(1);
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
    }

    public void StopPauseButton() 
    {
        Time.timeScale = 1.0f;
        _pausePanel.SetActive(false);
    }
}