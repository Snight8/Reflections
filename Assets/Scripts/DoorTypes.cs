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
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player" && PlayerDoor == true)
        {
            Destroy(gameObject);
        }
    }
}
