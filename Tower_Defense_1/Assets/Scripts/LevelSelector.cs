using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader sceneFader;

    public Button[] levelButtons; 
    public void Select(string levelName)
    {
        sceneFader.FadeTo(levelName);
    }
}
