using System.Collections;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private  TMP_Text _timerText;
    [SerializeField] private LevelsSO _config;
    [SerializeField] private GameObject _victory;
    [SerializeField] private GameObject _defeat;
    [SerializeField] private CounterKristall _countKristall;
    private bool _stopTimer;


    private void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        int _smoothness;
        float currentTime = _config.TimeOnLevel[SaveGame.Data.CurrentLevel];

        _smoothness = 1;

        while (currentTime > 0)
        {
            _timerText.text = currentTime.ToString();
            currentTime -= _smoothness;
            yield return new WaitForSeconds (_smoothness);
        }

        _timerText.text = "Время вышло";
        Time.timeScale = 0;
        int count = _config.KristallsOnLevel[SaveGame.Data.CurrentLevel];
        if (_countKristall.CounterBlue >= count || _countKristall.CounterGreen >= count || _countKristall.CounterRed >= count)
        {
            _victory.SetActive(true);
 
        }
        else
        {
            _defeat.SetActive(true);
        }
    }
}