using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 speed;
    [SerializeField] private Transform target;

    void Update()
    {
        target.Rotate(speed * Time.deltaTime);
    }
}