using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameSoundManager : MonoBehaviour
{
    public AudioSource AudioS;
    private float musicVolume = 1f;
    public Text OnOffText;
    public AudioSource[] ASArr;

    void Start()
    {
        OnOffText.text = ":OFF";
    }

    void Update()
    {
        AudioS.volume = musicVolume;
        if (musicVolume == 0)
            OnOffText.text = ":ON";
        else if (musicVolume > 0)
            OnOffText.text = ":OFF";
    }

    public void VolumeControll(float volume)
    {
        musicVolume = volume;
    }

    //음소거하기
    public void Mute()
    {
        musicVolume = 0f;
        OnOffText.text = ":ON";
    }
}
