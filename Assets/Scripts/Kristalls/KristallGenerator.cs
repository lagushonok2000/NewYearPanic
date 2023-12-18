using System.Collections;
using UnityEngine;

public class KristallGenerator : MonoBehaviour
{
    [SerializeField] private KristallsGroup[] _kristallsGroup;
    [SerializeField] private Material[] _kristallMaterial;
    [SerializeField] private Kristall _prefab;
    [SerializeField] private int _countGroup;
    [SerializeField] private int _countKristallInGroupMin;
    [SerializeField] private int _countKristallInGroupMax;
    [SerializeField] private float _respawnTime;
    private Kristall[] _allKristall;
    private bool _stopTimer;

    private void Start()
    {
        _allKristall= new Kristall[_kristallsGroup.Length * _kristallsGroup[0].SpawnPoints.Length];
        StartSpawnAllKristalls();
        SpawnKristalls();
        StartCoroutine(Timer());
    }

    private void StartSpawnAllKristalls()
    {
        for (int i = 0; i < _allKristall.Length; i++)
        {
            _allKristall[i] = GameObject.Instantiate(_prefab);
            _allKristall[i].gameObject.SetActive(false);
        }
        int k = 0;
        for (int i = 0; i < _kristallsGroup.Length; i++)
        {
            for (int j = 0; j < _kristallsGroup[i].SpawnPoints.Length; j++)
            {
                _allKristall[k].transform.position = _kristallsGroup[i].SpawnPoints[j].transform.position;
                _allKristall[k].transform.parent = _kristallsGroup[i].SpawnPoints[j].transform;
                _kristallsGroup[i].SpawnPoints[j].Kristall = _allKristall[k];
                k++;
            }
        }
    }

    private void SpawnKristalls()
    {
        for (int i = 0; i < _countGroup; i++)
        {
            int indexGroup = Random.Range(0, _kristallsGroup.Length);

            while (!_kristallsGroup[indexGroup].IsFree) // проверка занята ли группа
            {
                indexGroup = Random.Range(0, _kristallsGroup.Length);
            }

            _kristallsGroup[indexGroup].IsFree = false;

            int indexMesh = Random.Range(0, _kristallMaterial.Length);
            int countKristalls = Random.Range(_countKristallInGroupMin, _countKristallInGroupMax);
            int currentCountKristalls = 0;

            while (currentCountKristalls < countKristalls)
            {
                int indexSpawnPoint = Random.Range(0, _kristallsGroup[indexGroup].SpawnPoints.Length);

                while (!_kristallsGroup[indexGroup].SpawnPoints[indexSpawnPoint].IsFree)
                {
                    indexSpawnPoint = Random.Range(0, _kristallsGroup[indexGroup].SpawnPoints.Length);
                }

                _kristallsGroup[indexGroup].SpawnPoints[indexSpawnPoint].IsFree = false;
                var kristall = _kristallsGroup[indexGroup].SpawnPoints[indexSpawnPoint].Kristall;
                kristall.gameObject.SetActive(true);
                kristall.KristallMeshRenderer.material = _kristallMaterial[indexMesh];
                kristall.ID = indexMesh;
                
                currentCountKristalls++;
            }
        }
    }

    private void SetAllKristallsOFF()
    {
        for (int i = 0; i < _allKristall.Length; i++)
        {
            _allKristall[i].gameObject.SetActive(false);
        } 
        for (int i = 0; i < _kristallsGroup.Length; i++)
        {
            _kristallsGroup[i].IsFree = true;

            for (int j = 0; j < _kristallsGroup[i].SpawnPoints.Length; j++)
            {
                _kristallsGroup[i].SpawnPoints[j].IsFree = true;
            }
        }
    }

    private IEnumerator Timer()
    {
        while (!_stopTimer)
        {
            yield return new WaitForSeconds(_respawnTime);
            SetAllKristallsOFF();
            SpawnKristalls();
        }
    }
}