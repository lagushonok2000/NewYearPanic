using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private GameObject _tutorialPanel;

    private void Start()
    {
        _continueButton.onClick.AddListener(Panel);
    }
    private void Panel()
    {
        _tutorialPanel.SetActive(false);
    }
}