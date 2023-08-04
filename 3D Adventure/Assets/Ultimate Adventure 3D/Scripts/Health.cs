using SimpleFPS;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField][Min(0)] private int healAmount;
    [SerializeField] private GameObject impactEffect;

    protected void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonController>() != null && 
            other.TryGetComponent(out Destructible destructible))
        {
            if (destructible.GetHitPoints() == destructible.GetMaxHitPoints()) return;

            Destroy(gameObject);

            destructible.Heal(healAmount);

            Instantiate(impactEffect);
        }
    }
}
