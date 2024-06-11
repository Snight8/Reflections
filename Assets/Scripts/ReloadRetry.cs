using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadRetry : MonoBehaviour
{
    public SceneLoader sl;
    // Update is called once per frame
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
