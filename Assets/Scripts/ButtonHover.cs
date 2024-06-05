using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{
    public Image buttonImage;
    public Text buttonText;

    public void OnHoverEnter()
    {
        buttonImage.color = Color.black; 
        buttonText.color = Color.white;
    }

    public void OnHoverExit()
    {
        buttonImage.color = Color.white;
        buttonText.color = Color.black;
    }
}
