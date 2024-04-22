using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirrors : MonoBehaviour
{
    public Camera realCamera;
    bool yourColliderDied = false;
    GameObject hesHere;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MirrorPlayer")
        {
            Debug.Log("You're in.");
            yourColliderDied = true;
            hesHere = other.gameObject;
            hesHere.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            hesHere.GetComponent<Collider>().enabled = false;
            StartCoroutine(MirrorDoesThings());
            StartCoroutine(GetOutPlease());
        }
    }

    private void OnCollisonExit(Collision other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MirrorPlayer")
        {
            Debug.Log("You're out.");
        }
    }

    IEnumerator MirrorDoesThings()
    {
        //camera has a color flash and a sound plays
        yourColliderDied = false;
        yield return null;
    }

    IEnumerator GetOutPlease()
    {
        yield return new WaitForSeconds(5);
        hesHere.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        hesHere.GetComponent<Collider>().enabled = true;
        yield return null;
    }
}
