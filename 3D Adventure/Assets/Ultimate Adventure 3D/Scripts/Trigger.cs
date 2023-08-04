using UnityEngine;
using UnityEngine.Events;
using SimpleFPS;

public class Trigger : MonoBehaviour
{
    public UnityEvent Enter;
    public UnityEvent Exit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FirstPersonController fps))
        {
            Enter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out FirstPersonController fps))
        {
            Exit.Invoke();
        }
    }
}