using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Vector3 input;
    public Vector3 movement;
    public float speed;
    public Transform player;
    public Transform playerMirror;
    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //end meth calculation
        player.Translate(MovementCalc(input));
        playerMirror.Translate(MovementCalc(input, true));
    }
    Vector3 MovementCalc(Vector3 input, bool flipX = false, bool flipZ = false)
    {
        if (flipX) input.x = -input.x;
        if (flipZ) input.z = -input.z;
        Vector3 movement = new Vector3(input.x * speed, 0, input.z * speed);
        return movement;
    }
}


