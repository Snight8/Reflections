using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

public class Mirrors : MonoBehaviour
{
    public GameObject StarParticles; 
    GameObject hesHere; // standard player
    GameObject twoOfThem; // mirror player
    public AudioClip mirrorPassSound; //the sound that plays when you're in the mirror. Get it?!??!/1!?
    public float SolidDistance = 1.7f;
    public Axis mirrorAxis;
    public float CloseEnough = 0.5f;
    public Collider mirrorCollider;

    private void Awake()
    {
        hesHere = GameObject.Find("Normal Player");
        twoOfThem = GameObject.Find("Mirror Player");
    }
    void Update()
    {
        float playerMirrorDist = 100;
        float mirrorPlayerMirrorDist = 100;
        float otherDistance = 100;
        if (mirrorAxis == Axis.X)
        {
            playerMirrorDist = Mathf.Abs(hesHere.transform.position.x);
            mirrorPlayerMirrorDist = Mathf.Abs(twoOfThem.transform.position.x);
            otherDistance = Mathf.Abs(hesHere.transform.position.z - twoOfThem.transform.position.z);
        }
        if (mirrorAxis == Axis.Z)
        {
            playerMirrorDist = Mathf.Abs(hesHere.transform.position.z);
            mirrorPlayerMirrorDist = Mathf.Abs(twoOfThem.transform.position.z);
            otherDistance = Mathf.Abs(hesHere.transform.position.x - twoOfThem.transform.position.x);
        }
        float yDistance = Mathf.Abs(hesHere.transform.position.y - twoOfThem.transform.position.y);
        mirrorCollider.isTrigger = (playerMirrorDist <= SolidDistance && mirrorPlayerMirrorDist <= SolidDistance) && (yDistance <= CloseEnough && otherDistance <= CloseEnough);
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 avgPos = (hesHere.transform.position + twoOfThem.transform.position) / 2;
            AudioSource.PlayClipAtPoint(mirrorPassSound, avgPos);
            Instantiate(StarParticles, avgPos, Quaternion.identity);
        }
    }
}
