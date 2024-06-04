using UnityEngine;
using UnityEngine.UI;

public class RestoreSliderValue : MonoBehaviour
{
    public string key;
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Slider>().value = PlayerPrefs.GetFloat(key);
    }
}
