using SimpleFPS;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Acceleration : MonoBehaviour
{
    [SerializeField][Tooltip("Множитель увеличения скорости и прыжка персонажа")] [Min(0)]
    private float bonusMult = 2;

    private float startWalkSpeed;
    private float startRunSpeed;
    private float startJumpspeed;

    private AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FirstPersonController fps))
        {
            startWalkSpeed = fps.m_WalkSpeed;
            startRunSpeed = fps.m_RunSpeed;
            startJumpspeed = fps.m_JumpSpeed;

            fps.m_WalkSpeed *= bonusMult;
            fps.m_RunSpeed *= bonusMult;
            fps.m_JumpSpeed *= bonusMult;

            sound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out FirstPersonController fps))
        {
            fps.m_WalkSpeed = startWalkSpeed;
            fps.m_RunSpeed = startRunSpeed;
            fps.m_JumpSpeed = startJumpspeed;
        }
    }
}