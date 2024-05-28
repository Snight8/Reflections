using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Vector3 input;
    public Vector3 movement;
    public float speed;
    public Transform player;
    public Transform playerMirror;
    //---adding temporary stuff to choose which mirror type---
    public bool zMirror;
    public bool xMirror;

    // Update is called once per frame
    private void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //end meth calculation
        player.Translate(MovementCalc(input));
        if (zMirror == true)
        {
            playerMirror.Translate(MovementCalc(input, true));
        }
        if (xMirror == true)
        {
            playerMirror.Translate(MovementCalc(input, false, true));
        }
        //defaults to no mirror movement

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private Vector3 MovementCalc(Vector3 input, bool flipX = false, bool flipZ = false)
    {
        if (flipX) input.x = -input.x;
        if (flipZ) input.z = -input.z;
        Vector3 movement = new Vector3(input.x * speed, 0, input.z * speed);
        return movement;
    }
}