using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    private AudioSource music;
    public GameObject musicObject;
    public Slider volume;
    private float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        musicObject = GameObject.FindWithTag("Music");
        music = musicObject.GetComponent<AudioSource>();
        musicVolume = PlayerPrefs.GetFloat("volume");
        music.volume = musicVolume;
        volume.value = musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);

    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }

}
