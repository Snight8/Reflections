using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public AudioSource UnclickSound;
    public AudioSource ClickSound;
    public GameObject thisWillGoAway; //this is just any object that we want to appear/disappear if you have something on the plate

    void OnTriggerEnter()
    {
        thisWillGoAway.SetActive(false);
        ClickSound.Play();
        transform.Translate(new Vector3(0, -0.15f, 0));
    }

    /*void OnTriggerStay()
    {
        thisWillGoAway.SetActive(false);
    }*/

    void OnTriggerExit()
    {
        thisWillGoAway.SetActive(true);
        UnclickSound.Play();
        transform.Translate(new Vector3(0, 0.15f, 0));
    }
}
