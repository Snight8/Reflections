using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Animator animator;
    public AudioSource selectSound;
    public AudioSource backSound;
    public AudioSource music;
    public Slider BgmSlider;
    public Slider SfxSlider;
    public AudioMixer mix;

    public void Start()
    {
        //load volumes into mixer/sliders from playerprefs
        float BgmVolume = PlayerPrefs.GetFloat("BgmVolume");
        float SfxVolume = PlayerPrefs.GetFloat("SfxVolume");
        BgmSlider.value = VolumeToSlider(BgmVolume);
        SfxSlider.value = VolumeToSlider(SfxVolume);
        mix.SetFloat("BgmVolume", BgmVolume);
        mix.SetFloat("SfxVolume", SfxVolume);
    }
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
        mix.SetFloat("BgmVolume", SliderToVolume(BgmSlider.value));
        PlayerPrefs.SetFloat("BgmVolume", SliderToVolume(BgmSlider.value));
    }
    public void UpdateSfxVolume()
    {
        mix.SetFloat("SfxVolume", SliderToVolume(SfxSlider.value));
        PlayerPrefs.SetFloat("SfxVolume", SliderToVolume(SfxSlider.value));
    }
    float SliderToVolume(float slider)
    {
        slider *= 100;
        slider -= 80;
        return slider;
    }
    float VolumeToSlider(float volume)
    {
        volume += 80;
        volume /= 100;
        return volume;
    }
}
