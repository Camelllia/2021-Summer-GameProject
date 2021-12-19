using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoOption : MonoBehaviour
{
    //해상도 조절 스크립트
    FullScreenMode screenMode;
    public Dropdown resolutionDropdown;
    List<Resolution> resolutions = new List<Resolution>();
    public int resolutionNum;

    void Start()
    {
        InitUI();
    }

    
    void InitUI()
    {
        for(int i = 0; i<Screen.resolutions.Length; i++)
        {
            if(Screen.resolutions[i].refreshRate == 60)
            {
                resolutions.Add(Screen.resolutions[i]);
            }
        }
        resolutions.AddRange(Screen.resolutions);
        resolutionDropdown.options.Clear();

        int optionNum = 0;

        foreach(Resolution Item in resolutions)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = Item.width + "x" + Item.height + " " + Item.refreshRate + "hz";
            resolutionDropdown.options.Add(option);

            if (Item.width == Screen.width && Item.height == Screen.height)
                resolutionDropdown.value = optionNum;
            optionNum++;
            
        }
        resolutionDropdown.RefreshShownValue();

    }

    public void DropboxOptionChange(int x)
    {
        resolutionNum = x;
    }

    public void FullScreenBtn(bool isFull)
    {
        screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }

    public void ApplyBtn()
    {
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height,screenMode);
    }
}
