using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    bool unlocked;
    public int levelNum;
    public int sceneIndex;
    
    // Start is called before the first frame update
    void Awake()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = levelNum.ToString();
        UnlockRefresh();
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
        SceneManager.LoadScene(sceneIndex);
    }
}
