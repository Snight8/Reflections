using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public MovingPlatform platformScript;
    CharacterController playercc;
    CharacterController mirrorcc;

    void Awake()
    {
        playercc = GameObject.Find("Normal Player").GetComponent<CharacterController>();
        mirrorcc = GameObject.Find("Mirror Player").GetComponent<CharacterController>();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MirrorPlayer")) platformScript.Run();
        {
            if (platformScript.touchRequired) platformScript.Run();

        }
        if (other.CompareTag("Player")) platformScript.MoveCharacterOnPlatform(playercc);
        if (other.CompareTag("MirrorPlayer")) platformScript.MoveCharacterOnPlatform(mirrorcc);
        if (other.CompareTag("Pushable")) platformScript.MoveObjectOnPlatform(other.transform);

    }
}
