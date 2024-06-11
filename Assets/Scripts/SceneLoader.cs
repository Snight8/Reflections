using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;
    public void LoadSceneWithTransition(int SceneIndex)
    {
        StartCoroutine(DoThing(SceneIndex));
    }
    IEnumerator DoThing(int SceneIndex)
    {
        animator.SetTrigger("EndScene");
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(SceneIndex);
        yield return null;
    }
}
