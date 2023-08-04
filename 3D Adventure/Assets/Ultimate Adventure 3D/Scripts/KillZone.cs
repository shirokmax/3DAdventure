using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Destructible destructible))
        {
            destructible.Kill();
        }
    }
}