using SimpleFPS;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MultipleTrigger : MonoBehaviour
{
    public List<Trigger> triggers = new List<Trigger>();
    [SerializeField] private GameObject messageBox;
    [SerializeField] private Text messageText;

    [SerializeField] private AudioClip inactiveSound;
    [SerializeField] private AudioClip activateSound;
    private AudioSource sound;

    public UnityEvent Activate;

    private bool isActivate;

    private int allTriggersCount;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        allTriggersCount = triggers.Count;
        messageText.text = $"Для активации нужно нажать на {triggers.Count}/{allTriggersCount} кнопок";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActivate == true) return;

        if (other.GetComponent<FirstPersonController>() != null)
        {
            if (triggers.Count == 0)
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

    public void CheckTrigger(Trigger trigger)
    {
        for (int i = 0; i < triggers.Count; i++)
        {
            if (triggers[i] == trigger)
            {
                triggers.Remove(triggers[i]);

                messageText.text = $"Для открытия нужно активировать {triggers.Count}/{allTriggersCount} кнопок";
            }
        }
    }
}
