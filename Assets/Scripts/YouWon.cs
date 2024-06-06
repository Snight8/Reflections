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
    public int levelNum;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "MirrorPlayer")
        {
            StartCoroutine(BigW());
        }
    }

    IEnumerator BigW()
    {
        if (PlayerPrefs.GetInt("HighestClearedLevel") < levelNum) PlayerPrefs.SetInt("HighestClearedLevel", levelNum);
        winSound.Play();
        yield return new WaitForSeconds(2.5f);
        if (levelNum != 5) SceneManager.LoadScene(levelNum + 1);
        else SceneManager.LoadScene(0);
        yield return null;
    }

    void Update()
    {
        timer += Time.deltaTime;
        completionPercentage = (timer % FadeTime)/FadeTime;
        render.material.color = Color.HSVToRGB(completionPercentage, 1, 1);

        // reload (this should not be in here but i have 6 minutes AAAAAAAAAAA)
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(levelNum);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            SceneManager.LoadScene(0);
        }
    }
}
