using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTypes : MonoBehaviour
{

    public bool PlayerDoor;
    public bool MirrorDoor;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided.");
        if (collision.gameObject.tag == "MirrorPlayer" && MirrorDoor == true)
        {
            StartCoroutine(GoThroughIt());
        }
        if (collision.gameObject.tag == "Player" && PlayerDoor == true)
        {
            StartCoroutine(GoThroughIt());
        }
    }

    IEnumerator GoThroughIt()
    {
        this.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(.5f);
        this.GetComponent<Collider>().enabled = true;
        yield return null;
    }
}
