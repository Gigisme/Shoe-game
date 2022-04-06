using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider VolumeSlider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {

            PlayerPrefs.SetFloat("MusicVolume", 1 / 4);
        }
        else
            Load();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = VolumeSlider.value;
        Save();
    }
    public void Load()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("MusicVolume", VolumeSlider.value);
    }
}
