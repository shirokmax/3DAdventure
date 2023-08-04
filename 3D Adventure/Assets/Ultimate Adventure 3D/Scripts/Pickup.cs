using SimpleFPS;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonController>() != null)
        {
            Destroy(gameObject);
        }
    }
}