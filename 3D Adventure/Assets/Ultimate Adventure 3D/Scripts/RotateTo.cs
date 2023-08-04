using UnityEngine;

public class RotateTo : MonoBehaviour
{
    [SerializeField][Min(0)] private float speed;
    [SerializeField] private Vector3 target;

    void Update()
    {
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(target), speed * Time.deltaTime);
    }
}