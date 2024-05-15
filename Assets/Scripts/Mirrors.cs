using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mirrors : MonoBehaviour
{
    public Image flashAColor; //it's that png you told me to have instead of camera for effects
    GameObject hesHere; // standard player
    GameObject twoOfThem; // mirror player
    public AudioClip passingThrough; //the sound that plays when you're in the mirror. Get it?!??!/1!?

    private void Awake()
    {
        hesHere = GameObject.Find("Player Character");
        twoOfThem = GameObject.Find("Mirror Character");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MirrorPlayer")
        {
            if(other.gameObject.tag == "Player")
            {
                constraintsForGameObject(1);
            }
            if (other.gameObject.tag == "MirrorPlayer")
            {
                constraintsForGameObject(2);
            }
            Debug.Log("You're in.");
            StartCoroutine(MirrorDoesThings());
            StartCoroutine(GetOutPlease());
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
        yield return new WaitForSeconds(0.25f); //the total of all the Waits in MirrorDoesThings need to be less than this Wait
        if (hesHere.gameObject.tag == "Player")
        {
            constraintsForGameObject(3);
        }
        if (twoOfThem.gameObject.tag == "MirrorPlayer")
        {
            constraintsForGameObject(4);
        }
        flashAColor.color = new Color32(0, 0, 0, 0);
        yield return null;
    }

    void constraintsForGameObject(int typeOfConstraints)
    {
        if (typeOfConstraints == 1)
        {
            hesHere.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            hesHere.GetComponent<Collider>().enabled = false;
        }

        if (typeOfConstraints == 2)
        {
            twoOfThem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            twoOfThem.GetComponent<Collider>().enabled = false;
        }

        if (typeOfConstraints == 3)
        {
            hesHere.GetComponent<Collider>().enabled = true;
            hesHere.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }

        if (typeOfConstraints == 4)
        {
            twoOfThem.GetComponent<Collider>().enabled = true;
            twoOfThem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
}
