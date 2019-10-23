﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioSG : MonoBehaviour
{
    public AudioSource source;
    public AudioClip hoverSound;
    public Button btn;
    SelectButton sB;
    MenuGestureInput mGI;
    bool updated;

    private void Start()
    {
        sB = FindObjectOfType<SelectButton>();
    }

    public void HoverSound()
    {
        if (updated)
        {
            btn.Select();

            if (source.isActiveAndEnabled)
            {
                source.PlayOneShot(hoverSound);
            }

            sB.SaveButton(btn);
        }
        updated = false;
    }

    public void CallTimer()
    {
        updated = true;
        mGI = FindObjectOfType<MenuGestureInput>();
        mGI.SaveBtn(btn);
        StartCoroutine(StartCountdown());
    }

    public IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(0.5f);
        source.Stop();
        HoverSound();
    }
}