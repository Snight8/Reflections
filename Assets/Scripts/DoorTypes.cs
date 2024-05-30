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
            this.GetComponent<Collider>().enabled = false;
        }
        if (collision.gameObject.tag == "Player" && PlayerDoor == true)
        {
            this.GetComponent<Collider>().enabled = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Uncollided.");
        if (collision.gameObject.tag == "MirrorPlayer" && MirrorDoor == true)
        {
            this.GetComponent<Collider>().enabled = true;
        }
        if (collision.gameObject.tag == "Player" && PlayerDoor == true)
        {
            this.GetComponent<Collider>().enabled = true;
        }
    }
}
