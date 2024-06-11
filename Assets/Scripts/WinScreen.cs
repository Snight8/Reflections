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
        sl = GameObject.Find("SceneTransition").GetComponent<SceneLoader>(); // this is a really sloppy implementation but manually assigning it isn't working for some reason
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
