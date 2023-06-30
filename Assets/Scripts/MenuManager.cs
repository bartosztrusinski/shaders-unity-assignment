using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioMixer audioMixer;

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", musicSlider.value);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", sfxSlider.value);
    }

    public void LoadGameScene()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        SceneManager.LoadScene("Game");
    }

    public void HandleMusicSliderChange(float value)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20f);
    }

    public void HandleSFXSliderChange(float value)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20f);
    }
}
