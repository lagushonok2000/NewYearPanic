using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    private void Start()
    {
        _restartButton.onClick.AddListener(RestartButton);
      
    }

    private void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}