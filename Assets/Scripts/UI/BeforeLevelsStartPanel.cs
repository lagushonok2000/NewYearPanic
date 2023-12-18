using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BeforeLevelsStartPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _startButton;
    [SerializeField] private TMP_Text _textPanel;
    [SerializeField] private string[] _levelsDiscription;
    [SerializeField] private SwordAttack _swordAttack;

    private void Start()
    {
        Time.timeScale = 0;
        _startButton.onClick.AddListener(StartGame);
        _textPanel.text = _levelsDiscription[SaveGame.Data.CurrentLevel];
    }

    private void StartGame()
    {
        _swordAttack.enabled = true;
        Time.timeScale = 1;
        _panel.SetActive(false);
    }
}
