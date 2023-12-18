using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseKristallsPanel : MonoBehaviour
{
    [SerializeField] private GameObject _kristallRed;
    [SerializeField] private GameObject _kristallGreen;
    [SerializeField] private GameObject _kristallBlue;
    [SerializeField] private CounterKristall _counterKristall;
    [SerializeField] private LevelsSO _config;
    [SerializeField] private Button _victoryNextButton;
    [SerializeField] private GameObject _chooseKristallPanel;
    [SerializeField] private Button _chooseBlue;
    [SerializeField] private Button _chooseRed;
    [SerializeField] private Button _chooseGreen;

    private void Start()
    {
        _victoryNextButton.onClick.AddListener(OpenPanel);
        _chooseBlue.onClick.AddListener(() => OpenNPCScene(KColor.Blue));
        _chooseGreen.onClick.AddListener(() => OpenNPCScene(KColor.Green));
        _chooseRed.onClick.AddListener(() => OpenNPCScene(KColor.Red));
    }

    public void OpenPanel()
    {
        int k = 0;
        int count = _config.KristallsOnLevel[SaveGame.Data.CurrentLevel];
        SaveGame.Data.CurrentLevel++;
        SaveGame.SaveData();
        if (_counterKristall.CounterRed >= count)
        {
            k++;
            CurrentLevels.KristallColor = KColor.Red;
        }
        if (_counterKristall.CounterGreen >= count)
        {
            k++;
            CurrentLevels.KristallColor = KColor.Green;
        }
        if (_counterKristall.CounterBlue >= count)
        {
            k++;
            CurrentLevels.KristallColor = KColor.Blue;
        }

        //если получили кристаллы только одного цвета = победа + переход на межуровневую сцену
        if (k == 1)
        {
            SceneManager.LoadScene(0);
            return;
        }
        Debug.Log(count);
        _chooseKristallPanel.SetActive(true);
        _kristallRed.SetActive(false);
        _kristallGreen.SetActive(false);
        _kristallBlue.SetActive(false);

        if (_counterKristall.CounterRed >= count) _kristallRed.SetActive(true);
        if (_counterKristall.CounterGreen >= count) _kristallGreen.SetActive(true);
        if (_counterKristall.CounterBlue >= count) _kristallBlue.SetActive(true);
    }
    private void OpenNPCScene(KColor color)
    {
        Debug.Log("швыпркыв");
        CurrentLevels.KristallColor = color;
        SceneManager.LoadScene(0);
    }
}