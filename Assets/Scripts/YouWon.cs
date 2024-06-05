using System.Collections;
using UnityEngine;

public class YouWon : MonoBehaviour
{
    public AudioClip winSound;
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
        AudioSource.PlayClipAtPoint(winSound, transform.position);
        yield return new WaitForSeconds(2.5f);
        Application.LoadLevel(Application.loadedLevel + 1);
        yield return null;
    }

    void Update()
    {
        timer += Time.deltaTime;
        completionPercentage = (timer % FadeTime)/FadeTime;
        render.material.color = Color.HSVToRGB(completionPercentage, 1, 1);
    }
}
