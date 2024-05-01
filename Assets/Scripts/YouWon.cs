using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWon : MonoBehaviour
{
    public AudioClip winSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "MirrorPlayer")
        {
            StartCoroutine(BigW());
        }
    }

    IEnumerator BigW()
    {
        AudioSource.PlayClipAtPoint(winSound, transform.position);
        yield return new WaitForSeconds(2.5f);
        Application.LoadLevel(Application.loadedLevel + 1);
        yield return null;
    }
}
