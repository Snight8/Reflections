using System.Linq;
using UnityEngine;

public class DebugMode : MonoBehaviour
{
    string inputString;
    bool debugEnabled;
    public GameObject debugIndicator;
    public GameObject levelSelectMenu;

    // Update is called once per frame
    void Update()
    {
        inputString += Input.inputString;
        if (inputString.ToLower().Contains("debug") && !debugEnabled)
        {
            debugEnabled = true;
            inputString = string.Empty;
        }
        if (inputString.ToLower().Contains("gubed") && debugEnabled)
        {
            debugEnabled = false;
            inputString = string.Empty;
        }
        debugIndicator.SetActive(debugEnabled);
        if( debugEnabled )
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                PlayerPrefs.SetInt("HighestClearedLevel", 0);
                RefreshLevels();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                PlayerPrefs.SetInt("HighestClearedLevel", 1);
                RefreshLevels();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                PlayerPrefs.SetInt("HighestClearedLevel", 2);
                RefreshLevels();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                PlayerPrefs.SetInt("HighestClearedLevel", 3);
                RefreshLevels();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                PlayerPrefs.SetInt("HighestClearedLevel", 4);
                RefreshLevels();
            }
        }
    }
    void RefreshLevels()
    {
        foreach (LevelButton button in levelSelectMenu.GetComponentsInChildren<LevelButton>().ToArray())
        {
            button.UnlockRefresh();
        }
    }
}