using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundTest : MonoBehaviour
{
    public Slider backVolume;
    private float backVol = 1f;
    public Text onoffText;

    void Start()
    {
        backVol = PlayerPrefs.GetFloat("backvol", 1f);
        backVolume.value = backVol;
        AudioListener.volume = backVolume.value;
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();

        if (backVolume.value > 0)
            onoffText.text = ":OFF";
        else if(backVolume.value == 0)
            onoffText.text = "ON";
    }

    public void SoundSlider()
    {
        AudioListener.volume = backVolume.value;
        backVol = backVolume.value;
        PlayerPrefs.SetFloat("backvol", backVol);
    }

    
    public void Mute()
    {
        backVolume.value = 0;
    }
}
