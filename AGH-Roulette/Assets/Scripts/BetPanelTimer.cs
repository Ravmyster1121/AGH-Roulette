﻿using UnityEngine;
using UnityEngine.UI;

public class BetPanelTimer : MonoBehaviour
{
    public Text amount;
    public Text bal;
    ReadNumbers rN;
    public float targetTime;
    bool finished;

    void Start()
    {
        finished = true;
        rN = FindObjectOfType<ReadNumbers>();
    }

    public void CallTimer()
    {
        finished = false;
        targetTime = 0.8f;
    }

    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f && targetTime > -1f && !finished)
        {
            TimerEnded();
            finished = true;
        }

    }

    void TimerEnded()
    {
        string num = amount.text;
        rN.ReadNumber(num);
    }
}
