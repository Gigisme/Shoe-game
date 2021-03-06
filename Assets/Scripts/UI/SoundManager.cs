using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider VolumeSlider;
    private AudioSource source;
    public static SoundManager Instance { get; private set; }
    void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {

            PlayerPrefs.SetFloat("MusicVolume", 1 / 4);
        }
        else
            Load();
    }
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        Instance = this;
    }
    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
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
