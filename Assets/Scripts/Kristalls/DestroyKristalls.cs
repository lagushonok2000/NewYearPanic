using UnityEngine;

public class DestroyKristalls : MonoBehaviour
{
    [SerializeField] private AudioSource _soundKristall;

    private void OnTriggerEnter(Collider other)
    {
        _soundKristall.Play();
        //gameObject.SetActive(false);
    }
}