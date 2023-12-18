using UnityEngine;
using UnityEngine.AI;

public class EnemyHauinting : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        _agent.SetDestination(_playerTransform.position);
    }
}
