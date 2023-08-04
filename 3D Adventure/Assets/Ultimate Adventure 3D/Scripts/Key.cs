using UnityEngine;

public class Key : Pickup
{
    [SerializeField] [Min(0)] private int count;
    [SerializeField] private GameObject impactEffect;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.TryGetComponent(out Bag bag))
        {
            bag.AddKeys(count);

            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }
    }
}