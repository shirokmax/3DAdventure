using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class KeyTrigger : MonoBehaviour
{
    [SerializeField] private int keysAmountToActivate;
    [SerializeField] private GameObject messageBox;

    [SerializeField] private AudioClip inactiveSound;
    [SerializeField] private AudioClip activateSound;
    private AudioSource sound;

    public UnityEvent Activate;

    private bool isActivate;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActivate == true) return;

        if (other.TryGetComponent(out Bag bag))
        {
            if (bag.RemoveKeys(keysAmountToActivate) == true)
            {
                Activate.Invoke();

                isActivate = true;

                sound.clip = activateSound;
                sound.Play();
            }
            else
            {
                messageBox.SetActive(true);

                sound.clip = inactiveSound;
                sound.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        messageBox.SetActive(false);
    }
}