using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadRetry : MonoBehaviour
{
    SceneLoader sl;
    void Awake()
    {
        sl = GameObject.Find("SceneTransition").GetComponent<SceneLoader>(); // have to use GameObject.Find(), due to the implementation of SceneTransition using DontDestroyOnLoad. Only the one from the menu will be used, which is impossible to assign ahead of time (since it won't be in the scene until runtime)
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            sl.LoadSceneWithTransition(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sl.LoadSceneWithTransition(0);
        }
    }
}
