using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject thisWillGoAway; //this is just any object that we want to appear/disappear if you have something on the plate

    private void OnTriggerEnter(Collider other)
    {
        //this.transform.position   //make pressure plate move down by 1 on the y axis (idk how)
        thisWillGoAway.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        thisWillGoAway.SetActive(true);
    }
}
