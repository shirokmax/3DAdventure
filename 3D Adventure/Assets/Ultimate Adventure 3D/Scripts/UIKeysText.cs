using UnityEngine;
using UnityEngine.UI;

public class UIKeysText : MonoBehaviour
{
    [SerializeField] private Text keysText;
    [SerializeField] private Bag bag;

    private void Start()
    {
        bag.ChangeKeysAmount.AddListener(OnChangeKeysAmount);
    }

    private void OnDestroy()
    {
        bag.ChangeKeysAmount.RemoveListener(OnChangeKeysAmount);
    }

    private void OnChangeKeysAmount()
    {
        keysText.text = bag.GetKeysAmount().ToString();
    }
}