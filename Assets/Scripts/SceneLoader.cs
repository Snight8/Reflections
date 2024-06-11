using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;
    public float FadeVolume = 0;
    public AudioMixer audioMixer;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SceneTransition");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    public void LoadSceneWithTransition(int SceneIndex)
    {
        StartCoroutine(DoThing(SceneIndex));
    }
    IEnumerator DoThing(int SceneIndex)
    {
        animator.SetTrigger("EndScene");
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(SceneIndex);
        animator.ResetTrigger("EndScene");
        // realistically, this should wait until the scene is done loading, but right now, it loads so fast that it doesn't matter. also i don't feel like figuring out how to make it wait for scene load atm.
        animator.SetTrigger("StartScene");
        yield return null;
    }
    void Update()
    {
        audioMixer.SetFloat("BgmFadeVolume", FadeVolume);
    }
}
