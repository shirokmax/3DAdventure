using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField] [Min(0)] private float speed;
    [SerializeField] private Transform target;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}