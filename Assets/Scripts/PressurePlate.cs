using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public AudioSource UnclickSound;
    public AudioSource ClickSound;
    public GameObject thisWillGoAway; //this is just any object that we want to appear/disappear if you have something on the plate
    bool pressed;
    bool pressedLastFrame;
    Vector3 initialPos;

    void Awake()
    {
        initialPos = transform.position;
        pressed = false;
        pressedLastFrame = false;
    }

    void OnTriggerStay()
    {
        pressed = true;
    }

    void OnTriggerExit()
    {
        pressed = false;
    }

    void Update()
    {
        if (pressed)
        {
            transform.position = initialPos + new Vector3(0, -0.15f, 0);
            if(!pressedLastFrame) ClickSound.Play();
        }
        else
        {
            transform.position = initialPos;
            if(pressedLastFrame) UnclickSound.Play() ;
        }
        thisWillGoAway.SetActive(!pressed);
        pressedLastFrame = pressed;
    }
}
