using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public static AudioController Ins;

    [Range(0, 1)]
    public float musicVolume;
    [Range(0, 1)]
    public float soundVolume;
    [Header("-----------Audio Source----------")]
    [SerializeField] AudioSource musicAus;
    [SerializeField] AudioSource soundAus;

    [Header("-----------Audio Clip-------------")]
    public AudioClip[] backgroundMusic;
    public AudioClip rightSound;
    public AudioClip wrongSound;
    public AudioClip loseSound;
    public AudioClip winSound;
    public AudioClip playSound;

    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Awake()
    {
        MakeSingleton();
    }
    // Start is called before the first frame update
    public void Start()
    {
        PlayBackgroundMusic();
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }
    private void Update()
    {
        if (musicAus && soundAus)
        {
            musicAus.volume = soundVolume;
            soundAus.volume = soundVolume;
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
        SetSFXVolume();
    }
    public void PlayBackgroundMusic()
    {
        if(musicAus && backgroundMusic != null && backgroundMusic.Length > 0)
        {
            int ranIdx = Random.Range(0, backgroundMusic.Length);
            if (backgroundMusic[ranIdx])
            {
                musicAus.clip = backgroundMusic[ranIdx];
                musicAus.volume = musicVolume;
                musicAus.Play();
            }
        }
    }
    public void PlaySound(AudioClip sound)
    {
        if(soundAus && sound)
        {
            soundAus.PlayOneShot(sound);
            soundAus.volume = soundVolume;
            soundAus.Play();
        }
    }

    public void PlayRightSound()
    {
        PlaySound(rightSound);
    }
    public void PlayWrongtSound()
    {
        PlaySound(wrongSound);
    }
    public void PlayWinSound()
    {
        PlaySound(winSound);
    }
    public void PlayLoseSound()
    {
        PlaySound(loseSound);
    }
    public void StopMusic()
    {
        if (musicAus)
        {
            musicAus.Stop();
        }
    }
    public void PlayGame()
    {
        PlaySound(playSound);
    }
    void MakeSingleton()
    {
        if (Ins == null)
        {
            Ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
