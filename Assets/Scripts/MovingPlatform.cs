using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Vector3 dir;
    public float speed;
    public PlatformHadKids targeting;
    int previousTargetIndex;
    public int currentTargetIndex;
    public Vector3[] targets;
    float DistanceToNextTarget;
    public bool running = true;
    public bool touchRequired;
    List<Collider> touchingObjects;

    void Start() //do not use void Awake here!! Awake is called on load, and it's possible that mirrored platforms won't load on the same frame, which will desync them!
    {
         transform.position = targets[0]; //ensuring that we start at the first target
         DistanceToNextTarget = Vector3.Distance(targets[0], targets[1]);
         dir = targeting.movementDir(targets[1]);
         currentTargetIndex = 1;
    }
    
    void Update()
    {
        //if (touchingObjects.Count == 0 && touchRequired) running = false;
        //else running = true;
        //Debug.Log(touchingObjects);
        if (running)
        {
            if (Vector3.Distance(transform.position, targets[previousTargetIndex]) >= DistanceToNextTarget) //checks for overshoot. if this condition is true, it's time to switch targets!
            {
                transform.position = targets[currentTargetIndex]; // snap to target position in case of overshoot
                previousTargetIndex = currentTargetIndex;
                if (currentTargetIndex == targets.Length - 1) currentTargetIndex = 0; // if at the end of target array, loop back to 0
                else currentTargetIndex++; //otherwise, increment the index by 1
                DistanceToNextTarget = Vector3.Distance(targets[previousTargetIndex], targets[currentTargetIndex]);
                dir = targeting.movementDir(targets[currentTargetIndex]);
            }
            transform.Translate(dir * speed * Time.deltaTime);
            /*foreach(Collider touchingObject in touchingObjects.ToArray())
            {
                touchingObject.transform.Translate(dir * speed * Time.deltaTime);
            }*/
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
    	//if the object is not already in the list
    	if(!touchingObjects.Contains(other))
    	{
    		//add the object to the list
    		touchingObjects.Add(other);
    	}
    }
    
    //called when something exits the trigger
    void OnTriggerExit(Collider other)
    {
    	//if the object is in the list
    	if(touchingObjects.Contains(other))
    	{
    		//remove it from the list
    		touchingObjects.Remove(other);
    	}
    }
}
