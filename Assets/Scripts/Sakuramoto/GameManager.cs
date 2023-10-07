using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    protected override bool IsDontDestroyOnLoad { get { return false; } }

    bool m_IsGameStart = false;
    bool m_IsTimeOver = false;

    void Start()
    {
        timer.Instance.TimeOverAction += TimeOver;
    }

    void Update()
    {
        
    }

    public void GameStart()
    {
        m_IsGameStart = true;
        PlayerScripts.Instance.GameStart();
        timer.Instance.GameStart();
    }

    public void TimeOver()
    {
        m_IsTimeOver = true;
        PlayerScripts.Instance.TimeOverEnd();
        TimeUpUI.Instance.TimeUp();
    }
}
