using UnityEngine;
public class MainMenu : MonoBehaviour
{
    public Animator animator;
    public void QuitButton()
    {
        Application.Quit();
    }
    public void LevelSelectButton()
    {
        animator.SetInteger("CurrentMenu", 1);
    }
    public void OptionsButton()
    {
        animator.SetInteger("CurrentMenu", 2);
    }
    public void CreditsButton()
    {
        animator.SetInteger("CurrentMenu", 3);
    }
    public void MainMenuButton()
    {
        animator.SetInteger("CurrentMenu", 0);
    }
}
