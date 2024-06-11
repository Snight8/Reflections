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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "MirrorPlayer")
        {
            StartCoroutine(BigW());
        }
    }

    IEnumerator BigW()
    {
        if (PlayerPrefs.GetInt("HighestClearedLevel") < SceneManager.GetActiveScene().buildIndex) PlayerPrefs.SetInt("HighestClearedLevel", SceneManager.GetActiveScene().buildIndex);
        winSound.Play();
        yield return new WaitForSeconds(2.5f);
        WinScreen.SetActive(true);
        yield return null;
    }

    void Update()
    {
        timer += Time.deltaTime;
        completionPercentage = (timer % FadeTime)/FadeTime;
        render.material.color = Color.HSVToRGB(completionPercentage, 1, 1);
    }
}
