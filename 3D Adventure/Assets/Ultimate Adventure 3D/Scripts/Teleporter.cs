using SimpleFPS;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Teleporter : MonoBehaviour
{
    [SerializeField] private Teleporter target;
    [HideInInspector] public bool IsReceived = false;

    private AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsReceived == true) return;

        if (other.TryGetComponent(out FirstPersonController fps))
        {
            fps.transform.position = target.transform.position;

            target.IsReceived = true;

            sound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out FirstPersonController fps))
        {
            IsReceived = false;
        }
    }
}