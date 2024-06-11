using UnityEngine;

public class SoundTest : MonoBehaviour
{
    bool MusicPlaying;
    public AudioSource Music;
    public AudioSource[] sounds;
    // Update is called once per frame
    void Update()
    {
        int id;
        int.TryParse(Input.inputString, out id);
        if (id > 0 && id-1 < sounds.Length)
        {
            sounds[id - 1].Play();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!Music.isPlaying) Music.Play();
            else Music.Stop();
        }
    }
}
