using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    [SerializeField][Min(0)] private float lifeTime;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}