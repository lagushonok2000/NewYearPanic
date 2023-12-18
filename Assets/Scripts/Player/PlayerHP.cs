using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private Image _hpBar;
    [SerializeField] private float _countHp;
    [SerializeField] private GameObject _defeatPanel;
    [SerializeField] private LevelsSO _config;
    private float _maxHp;
    private float _sub;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            _countHp = _config.PlayerHP[SaveGame.Data.CurrentLevel];
        }

        _sub = _config.EnemyDamage[SaveGame.Data.CurrentLevel];
        _maxHp = _countHp;
        _hpBar.fillAmount = _countHp / _maxHp;
    }

    public void HpSubtruck(float sub)
    {
        if (_countHp <= sub)
        {
            _hpBar.fillAmount = 0;
            _defeatPanel.SetActive(true);
            Time.timeScale = 0;
            return;
        }
        _countHp -= sub;
        _hpBar.fillAmount = _countHp / _maxHp;
    }

    private void OnCollisionStay (Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            HpSubtruck(_sub);
        }
    }
}