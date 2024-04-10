using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "MsinMenu";
    public SceneFader sceneFader;
    
    public string nextLevel = "Level02";
    public int levelToReach = 2;
    
    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToReach);
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }

}
