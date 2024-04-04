using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI livesShadow;

    private void Update()
    {
        livesText.text = PlayerStats.Lives + " LIVES";
        livesShadow.text = PlayerStats.Lives + " LIVES"; 
    }
}
