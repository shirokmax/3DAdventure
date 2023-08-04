using SimpleFPS;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UIPauseMenu : MonoBehaviour
{
    [SerializeField] private FirstPersonController FPS;
    [SerializeField] private GameObject pauseMenu;
    private bool isPaused;

    [SerializeField] private AudioClip pause;
    [SerializeField] private AudioClip unPause;
    private AudioSource sound;

    private void Start()
    {
        pauseMenu.SetActive(false);
        sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && isPaused == false)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.P) && isPaused == true)
        {
            UnPause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        FPS.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pauseMenu.SetActive(true);

        sound.clip = pause;
        sound.Play();

        isPaused = true;
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
        FPS.enabled = true;

        sound.clip = unPause;
        sound.Play();

        pauseMenu.SetActive(false);

        isPaused = false;
    }
}
