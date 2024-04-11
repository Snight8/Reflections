using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorTypes : MonoBehaviour
{
    public Camera realCamera;
    public bool xMirrorLeft;
    public bool xMirrorRight;
    public bool zMirrorBottom;
    public bool zMirrorTop;

    void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(MirrorDoesThings());

        if (xMirrorLeft == true)
        {
            
        }

        if (xMirrorRight == true)
        {
           
        }

        if (zMirrorBottom == true)
        {
           
        }

        if (zMirrorTop == true)
        {
           
        }
    }

    IEnumerator MirrorDoesThings()
    {
        //camera has a color flash and a sound plays
        yield return null;
    }
}
