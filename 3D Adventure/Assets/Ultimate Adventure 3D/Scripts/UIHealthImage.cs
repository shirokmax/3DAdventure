using UnityEngine;
using UnityEngine.UI;

public class UIHealthImage : MonoBehaviour
{
    [SerializeField] private Image healhImage;
    [SerializeField] private Destructible destructible;

    private void Start()
    {
        destructible.ChangeHitPoints.AddListener(OnChangeHitPoints);
        healhImage.color = new Color(255, 255, 0);
    }

    private void OnDestroy()
    {
        destructible.ChangeHitPoints.RemoveListener(OnChangeHitPoints);
    }

    private void OnChangeHitPoints()
    {
        healhImage.fillAmount = (float) destructible.GetHitPoints() / (float) destructible.GetMaxHitPoints();
        
        if (healhImage.fillAmount > 0.3f) healhImage.color = new Vector4(healhImage.color.r, (healhImage.fillAmount * 255) / 255.0f, healhImage.color.b, 1);
        else healhImage.color = new Vector4(healhImage.color.r, 0, healhImage.color.b, 1);
    }
}