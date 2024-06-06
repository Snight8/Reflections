using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonHover : MonoBehaviour
{
    public Image buttonImage;
    public TextMeshProUGUI buttonText;

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
