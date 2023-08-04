using SimpleFPS;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SpringPlatform : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Множитель увеличения высоты прыжка персонажа")]
    [Min(0)]
    private float jumpMult = 2;

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
            startJumpspeed = fps.m_JumpSpeed;

            fps.m_Jump = true;
            fps.m_JumpSpeed *= jumpMult;

            sound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out FirstPersonController fps))
        {
            fps.m_JumpSpeed = startJumpspeed;
        }
    }
}