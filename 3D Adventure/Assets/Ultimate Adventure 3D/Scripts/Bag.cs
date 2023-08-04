using UnityEngine;
using UnityEngine.Events;

public class Bag : MonoBehaviour
{
    [SerializeField] [Min(0)] private int keysAmount;

    [HideInInspector] public UnityEvent ChangeKeysAmount;

    public void AddKeys(int amount)
    {
        keysAmount += amount;
        ChangeKeysAmount.Invoke();
    }

    public bool RemoveKeys(int amount)
    {
        if (keysAmount - amount < 0) return false;

        keysAmount -= amount;

        ChangeKeysAmount.Invoke();

        return true;
    }

    public int GetKeysAmount()
    {
        return keysAmount;
    }
}