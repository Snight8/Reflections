using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Animator animator;
    public AudioSource selectSound;
    public AudioSource backSound;
    public AudioSource music;
    public Slider BgmSlider;
    public Slider SfxSlider;
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
    public void UpdateBgmVolume()
    {
        music.volume = BgmSlider.value;
        PlayerPrefs.SetFloat("BgmVolume", BgmSlider.value);
    }
    public void UpdateSfxVolume()
    {
        selectSound.volume = SfxSlider.value;
        backSound.volume = SfxSlider.value;
        PlayerPrefs.SetFloat("SfxVolume", SfxSlider.value);
    }
}
