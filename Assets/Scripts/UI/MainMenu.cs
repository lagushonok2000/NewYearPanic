using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startNewGameButton;
    [SerializeField] private Button _continueGameButton;
    [SerializeField] private Button _exitGameButton;

    private void Start()
    {
        _startNewGameButton.onClick.AddListener(StartNewGame);
        _continueGameButton.onClick.AddListener(ContinueGame);
        _exitGameButton.onClick.AddListener(ExitGame);
        SaveGame.LoadData();
    }

    private void StartNewGame()
    {
        SaveGame.Data.CurrentLevel = 0;
        SaveGame.SaveData();
        SceneManager.LoadScene(0); // поставить 2 вместо 0
    }

    private void ContinueGame()
    {
        SceneManager.LoadScene(SaveGame.Data.CurrentIndexScene);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}