using UnityEngine;

public class VolumeSet : MonoBehaviour
{
    public string keyToUse;
    public AudioSource source;

    void Awake()
    {
        source.volume = PlayerPrefs.GetFloat(keyToUse);
    }
}
