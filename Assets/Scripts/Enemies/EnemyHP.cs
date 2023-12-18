using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private float _sub;
    [SerializeField] private Image _hpBar;
    [SerializeField] private float _countHp;
    [SerializeField] private LevelsSO _config;
    private float _maxHp;

    private void Start()
    {
        _maxHp = _countHp;
        _hpBar.fillAmount = _countHp / _maxHp;


        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            _sub = _config.PlayerDamage[SaveGame.Data.CurrentLevel];
        }
    }

    public void HpSubtruck(float sub)
    {
        Debug.Log(sub + "     " + _countHp);
        if (_countHp <= sub)
        {
           GameObject.Destroy(gameObject);
            return;
        }
        _countHp -= sub;
        _hpBar.fillAmount = _countHp / _maxHp;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("111");
        if (other.gameObject.layer == 8)
        {
            HpSubtruck(_sub);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}