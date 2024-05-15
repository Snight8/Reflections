using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHadKids : MonoBehaviour
{
    public Vector3 movementDir(Vector3 Target)
    {
        transform.LookAt(Target);
        return transform.forward;
    }
}
