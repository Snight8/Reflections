using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWon : MonoBehaviour
{
    public AudioSource winSound;
    float timer;
    public float FadeTime;
    public Renderer render;
    float completionPercentage;
    public GameObject WinScreen;
    public Animator WinAnimator;
    public float CubeAlpha = 1;

    public NewPlayerMovement player;
    public NewPlayerMovement mirrorPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MirrorPlayer"))
        {
            StartCoroutine(BigW());
        }
    }

    IEnumerator BigW()
    {
        winSound.Play();
        WinAnimator.SetTrigger("CubeCollected");
        yield return new WaitForSeconds(1);
        if (PlayerPrefs.GetInt("HighestClearedLevel") < SceneManager.GetActiveScene().buildIndex) PlayerPrefs.SetInt("HighestClearedLevel", SceneManager.GetActiveScene().buildIndex);
        WinScreen.SetActive(true);
        player.movementUnlocked = false;
        mirrorPlayer.movementUnlocked = false;
        yield return null;
    }

    void Update()
    {
        timer += Time.deltaTime;
        completionPercentage = (timer % FadeTime)/FadeTime;
        Color newColor = Color.HSVToRGB(completionPercentage, 1, 1);
        newColor.a = CubeAlpha;
        render.material.color = newColor;
    }
}
