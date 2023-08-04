using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField][Min(0)] private int damage;
    [SerializeField][Min(0)] private float damageRate;

    private Destructible destructible;
    private float timer;

    private void Start()
    {
        timer = damageRate;
    }

    private void Update()
    {
        if (destructible == null) return;

        timer += Time.deltaTime;

        if (timer >= damageRate)
        {
            destructible.ApplyDamage(damage);

            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        destructible = other.GetComponent<Destructible>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Destructible>() == destructible)
        {
            destructible = null;

            timer = damageRate;
        }     
    }
}