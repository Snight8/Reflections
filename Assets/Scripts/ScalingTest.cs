using UnityEngine;

public class ScalingTest : MonoBehaviour
{
    public RectTransform rectTransform;
    public RectTransform canvasRect;
    public Vector2 resolution = new (128, 128);
    // Update is called once per frame
    void Update()
    {
        rectTransform.localScale = new Vector3((canvasRect.rect.height / canvasRect.rect.width) * resolution.x / resolution.y, 1, 1);
    }
}
