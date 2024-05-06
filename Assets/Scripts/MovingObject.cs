using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
public float objectSpeed;

public Transform moveHere1;
public Transform moveHere2;
int placeToMoveTo = 1;
Transform currentPlaceItsAt;

private void Start()
    {
        moveHere1 = transform; //sets its current spot as the 1st point
        currentPlaceItsAt = moveHere1; //tells the place it's at 
    }

void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MirrorPlayer")
        {
            if (placeToMoveTo == 1)
            {
                placeToMoveTo = 2;
                currentPlaceItsAt = moveHere2;
            }
            else
            {
                placeToMoveTo = 1;
                currentPlaceItsAt = moveHere1; //can add more points for it to go if we add the transforms and end the last one with this line of code
            }
        }
    transform.Translate(0, 0, objectSpeed * Time.deltaTime);
    }
}