using UnityEngine;

public class TilingWithScale : MonoBehaviour
{
    public float multiplier = 1f;
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Renderer>().material.mainTextureScale = new Vector2(transform.lossyScale.x, transform.lossyScale.z) * multiplier;
    }
}
