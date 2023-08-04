using UnityEngine;
using UnityEngine.Events;

public class ActivateTimer : MonoBehaviour
{
    [SerializeField] private float time;
    
    public UnityEvent TimerEnd;

    private float timer;

    private void Awake()
    {
        enabled = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= time)
        {
            TimerEnd.Invoke();

            enabled = false;
        }
    }

    private void OnDisable()
    {
        timer = 0;
    }
}