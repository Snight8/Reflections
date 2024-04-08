using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTypes : MonoBehaviour
{

    public bool PlayerDoor;
    public bool MirrorDoor;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

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
