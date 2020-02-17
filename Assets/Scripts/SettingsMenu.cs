using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    [SerializeField]
    private GameObject settingsMenu;
    [SerializeField]
    private GameObject backMenu;
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Dropdown resolutionDropDown;
    [SerializeField]
    private GameObject soundButton;
    [SerializeField]
    private GameObject muteButton;
    [SerializeField]
    private Slider volumeSlider;


    Resolution[] resolutions;

    void Start()
    {
        resolutions =  Screen.resolutions;
        resolutionDropDown.ClearOptions();

        int currentResolutionIndex = 0;

        List<string> options = new List<string>();
        for(int i = 0; i < resolutions.Length; i++)
        {
            options.Add(resolutions[i].width + " x " + resolutions[i].height);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        ModifyVolume(volume);
        if (volume == -80f)
        {
            ActiveMuteButton();
        }
        else
        {
            ActiveSoundButton();
        }
        
        //audioMixer.SetFloat("volume", volume);
    }

    private void ModifyVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void Retour()
    {
        settingsMenu.SetActive(false);
        backMenu.SetActive(true);
    }

    private void ActiveMuteButton()
    {
        soundButton.SetActive(false);
        muteButton.SetActive(true);
    }

    private void ActiveSoundButton()
    {
        muteButton.SetActive(false);
        soundButton.SetActive(true);
    }

    public void MuteButton()
    {
        ModifyVolume(-80f);
        ActiveMuteButton();

    }

    public void SoundButton()
    {
        ActiveSoundButton();
        ModifyVolume(volumeSlider.value);
    }
}
