using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundsSurvived : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    public TextMeshProUGUI roundsShadow;
    
    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        roundsShadow.text = "0";
        int round = 0;

        yield return new WaitForSeconds(0.7f);
        while (round < PlayerStats.rounds)
        {
            round++;
            roundsShadow.text = round.ToString();
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(0.05f);
        }
    }
}
