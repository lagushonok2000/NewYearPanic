using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _attackSound;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("attack");
            _attackSound.Play();
        }
    }
}