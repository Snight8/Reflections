using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirrors : MonoBehaviour
{
    public Camera realCamera;
    GameObject hesHere;
    GameObject twoOfThem;
    public bool realPlayerMirror;
    public bool mirrorPlayerMirror;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MirrorPlayer")
        {
            if(realPlayerMirror == true && other.gameObject.tag == "Player")
            {
                hesHere = other.gameObject;
                constraintsForGameObject(1);
                hesHere.GetComponent<Collider>().enabled = false;
            }
            else if (mirrorPlayerMirror == true && other.gameObject.tag == "MirrorPlayer")
            {
                twoOfThem = other.gameObject;
                constraintsForGameObject(2);
                twoOfThem.GetComponent<Collider>().enabled = false;
            }
            Debug.Log("You're in.");
            StartCoroutine(MirrorDoesThings());
            StartCoroutine(GetOutPlease());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MirrorPlayer")
        {
            Debug.Log("You're out.");
        }
    }

    void constraintsForGameObject(int typeOfConstraints)
    {
        if (typeOfConstraints == 1)
        {
            hesHere.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }

        if (typeOfConstraints == 2)
        {
            twoOfThem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    IEnumerator MirrorDoesThings()
    {
        realCamera.clearFlags = CameraClearFlags.Color;
        yield return new WaitForSeconds(.1f);
        realCamera.backgroundColor = Color.blue;
        yield return new WaitForSeconds(.1f);
        realCamera.backgroundColor = Color.white;
        yield return new WaitForSeconds(.1f);
        realCamera.backgroundColor = Color.cyan;
        yield return new WaitForSeconds(.1f);
        realCamera.clearFlags = CameraClearFlags.Skybox;
        yield return null;
    }

    IEnumerator GetOutPlease()
    {
        yield return new WaitForSeconds(1);
        if (realPlayerMirror == true)
        {
            hesHere.GetComponent<Collider>().enabled = true;
            hesHere.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
        else if (mirrorPlayerMirror == true)
        {
            twoOfThem.GetComponent<Collider>().enabled = true;
            twoOfThem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
        yield return null;
    }
}
