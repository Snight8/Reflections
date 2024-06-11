using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    SceneLoader sl;
    public Button NextButton;
    void Start()
    {
        NextButton.interactable = SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings - 1;
        sl = GameObject.Find("SceneTransition").GetComponent<SceneLoader>(); // have to use GameObject.Find(), due to the implementation of SceneTransition using DontDestroyOnLoad. Only the one from the menu will be used, which is impossible to assign ahead of time (since it won't be in the scene until runtime)
    }
    public void NextLevel()
    {
        sl.LoadSceneWithTransition(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MainMenu()
    {
        sl.LoadSceneWithTransition(0);
    }
    public void Replay()
    {
        sl.LoadSceneWithTransition(SceneManager.GetActiveScene().buildIndex);
    }
}
