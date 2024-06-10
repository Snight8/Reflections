using UnityEngine;

public class ScalingTest : MonoBehaviour
{
    public RectTransform rectTransform;
    public RectTransform canvasRect;
    // Update is called once per frame
    void Update()
    {
        rectTransform.localScale = new Vector3((canvasRect.rect.height / canvasRect.rect.width), 1, 1);
    }
}
