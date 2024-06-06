using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public MovingPlatform platformScript;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MirrorPlayer")) platformScript.Run();
        {
            if (platformScript.touchRequired) platformScript.Run();
            platformScript.MoveObjectOnPlatform(other.transform);
        }

    }
}
