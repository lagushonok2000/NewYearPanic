using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private Vector3 _distance;

    void Start()
    {
        _distance = transform.position - _playerTransform.position;
    }

    void LateUpdate()
    {
        transform.position = _playerTransform.position + _distance;
    }
}