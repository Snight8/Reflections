using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float platformSpeed;
    Vector3 startingPoint;
    public Vector3 secondPoint;
    public Vector3 thirdPoint;
    public Vector3 endingPoint;
    Transform goToThisVector; //alright idk what im supposed to do with this but i put it here based on some enemy patrol script

    // Start is called before the first frame update
    void Start()
    {
        startingPoint = this.GetComponent<Vector3>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MirrorPlayer")
        {
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MirrorPlayer")
        {

        }
    }

    IEnumerator PlatformGo()
    {
        yield return null;
    }
}
