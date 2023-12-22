using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private float _sub;
    [SerializeField] private Image _hpBar;
    [SerializeField] private float _countHp;
    [SerializeField] private LevelsSO _config;
    [SerializeField] private AudioSource _destroySound;
    [SerializeField] private Collider _collider;
    [SerializeField] private GameObject _mesh;
    [SerializeField] private GameObject _canvas;
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

    private IEnumerator timer()
    {
        _collider.enabled = false;
        _canvas.SetActive(false);
        _mesh.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        GameObject.Destroy(gameObject);

    }

    public void HpSubtruck(float sub)
    {
        Debug.Log(sub + "     " + _countHp);
        if (_countHp <= sub)
        {
            
            _destroySound.Play();
            StartCoroutine(timer());
            return;
        }
        _countHp -= sub;
        _hpBar.fillAmount = _countHp / _maxHp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            HpSubtruck(_sub);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}