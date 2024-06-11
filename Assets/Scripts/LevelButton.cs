using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    bool unlocked;
    public int levelNum;
    public int sceneIndex;
    SceneLoader sl;
    
    // Start is called before the first frame update
    void Awake()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = levelNum.ToString();
        UnlockRefresh();
        sl = GameObject.Find("SceneTransition").GetComponent<SceneLoader>(); // have to use GameObject.Find(), due to the implementation of SceneTransition using DontDestroyOnLoad. Only the one from the menu will be used, which is impossible to assign ahead of time (since it won't be in the scene until runtime)
    }
    public void UnlockRefresh()
    {
        unlocked = PlayerPrefs.GetInt("HighestClearedLevel") + 1 >= levelNum; // if the highest cleared level is before this level, it should be unlocked.
        if (!unlocked)
        {
            GetComponent<Button>().interactable = false;
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            GetComponent<Button>().interactable = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void LoadScene()
    {
        Debug.Log("LoadScene called");
        sl.LoadSceneWithTransition(sceneIndex);
    }
}
