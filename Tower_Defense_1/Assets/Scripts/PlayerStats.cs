using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;
    public static int rounds;
    public static int Lives;
    public int startingLives = 20;

    private void Start()
    {
        Lives = startingLives;
        Money = startMoney;
        rounds = 0;
    }
}
