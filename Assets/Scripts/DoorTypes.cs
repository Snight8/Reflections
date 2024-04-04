using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTypes : MonoBehaviour
{

    public bool PlayerDoor;
    public bool MirrorDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MirrorPlayer" && MirrorDoor == true)
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player" && PlayerDoor == true)
        {
            Destroy(gameObject);
        }
    }
}
