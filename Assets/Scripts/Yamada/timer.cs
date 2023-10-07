using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class timer : SingletonMonoBehaviour<timer>
{
    protected override bool IsDontDestroyOnLoad { get { return false; } }

    bool m_IsGameStarted = false;

    // Start is called before the first frame update
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    float RemainingTime = 180;

    public Action TimeOverAction { get; set; }

    protected override void Awake()
    {
        base.Awake();
        text.text = RemainingTime.ToString("F2");
    }

    public void GameStart()
    {
        m_IsGameStarted = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!m_IsGameStarted) { return; }

        if (RemainingTime > 0)
        {
            RemainingTime = RemainingTime - Time.deltaTime;
            if (RemainingTime <= 0)
            {
                RemainingTime = 0;
                TimeOverAction();
            }
            text.text = RemainingTime.ToString("F2");
        }
    }
}
