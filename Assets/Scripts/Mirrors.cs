using System.Collections;
using UnityEngine;

public class Mirrors : MonoBehaviour
{
    public GameObject StarParticles; 
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
        Vector3 avgPos = (hesHere.transform.position + twoOfThem.transform.position) / 2;
        AudioSource.PlayClipAtPoint(passingThrough, avgPos);
        Instantiate(StarParticles, avgPos, Quaternion.identity);
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
