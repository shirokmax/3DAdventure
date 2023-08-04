using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Destructible : MonoBehaviour
{
    [SerializeField] [Min(0)] private int maxHitPoints;
    private int hitPoints;

    [HideInInspector] public UnityEvent ChangeHitPoints;
    [HideInInspector] public UnityEvent TakeDamage;
    public UnityEvent OnDestroyed;

    private void Start()
    {
        hitPoints = maxHitPoints;
        ChangeHitPoints.Invoke();
    }

    public void ApplyDamage(int damage)
    {
        hitPoints -= damage;
        ChangeHitPoints.Invoke();
        TakeDamage.Invoke();

        if (hitPoints <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        hitPoints = 0;
        ChangeHitPoints.Invoke();
        TakeDamage.Invoke();

        OnDestroyed.Invoke();
    }

    public void Heal(int healAmount)
    {
        if (hitPoints < maxHitPoints)
        {
            if (hitPoints + healAmount > maxHitPoints)
            {
                hitPoints = maxHitPoints;
            }
            else
            {
                hitPoints += healAmount;
            }

            ChangeHitPoints.Invoke();
        }
    }

    public int GetHitPoints()
    {
        return hitPoints;
    }

    public int GetMaxHitPoints()
    {
        return maxHitPoints;
    }
}