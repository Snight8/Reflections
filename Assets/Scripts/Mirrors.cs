﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mirrors : MonoBehaviour
{
    public Image flashAColor; //it's that png you told me to have instead of camera for effects
    GameObject hesHere; // standard player
    GameObject twoOfThem; // mirror player
    public bool realPlayerMirror; // is the mirror this script is assigned to for the real player?
    public bool mirrorPlayerMirror; //  is the mirror this script is assigned to for the mirror player?
    public AudioClip passingThrough; //the sound that plays when you're in the mirror. Get it?!??!/1!?

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
        AudioSource.PlayClipAtPoint(passingThrough, transform.position);
        flashAColor.color = new Color32(255,255,255,100); //white
        yield return new WaitForSeconds(.05f);
        flashAColor.color = new Color32(96, 237, 247, 100); //cyan
        yield return new WaitForSeconds(.05f);
        flashAColor.color = new Color32(12, 42, 194, 100); //blue
        yield return new WaitForSeconds(.05f);
        flashAColor.color = new Color32(76, 125, 199, 100); //light blue
        yield return new WaitForSeconds(.05f);
        yield return null;
    }

    IEnumerator GetOutPlease()
    {
        yield return new WaitForSeconds(0.25f); //the total of all the Waits in MirrorDoesThings need to be less than this wait
        if (realPlayerMirror == true && hesHere.gameObject.tag == "Player")
        {
            hesHere.GetComponent<Collider>().enabled = true;
            hesHere.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
        if (mirrorPlayerMirror == true && twoOfThem.gameObject.tag == "MirrorPlayer")
        {
            twoOfThem.GetComponent<Collider>().enabled = true;
            twoOfThem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
        flashAColor.color = new Color32(0, 0, 0, 0);
        yield return null;
    }
}
