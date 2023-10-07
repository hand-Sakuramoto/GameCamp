using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeUpUI : SingletonMonoBehaviour<TimeUpUI>
{
    protected override bool IsDontDestroyOnLoad {  get { return false; } }

    [SerializeField]
    TextMeshProUGUI m_Text;

    [SerializeField]
    float m_TimeUpTextDisplayTime = 1f;

    bool m_IsTimeUp = false;

    protected override void Awake()
    {
        base.Awake();
        m_Text.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!m_IsTimeUp) { return; }

        m_TimeUpTextDisplayTime -= Time.deltaTime;

        if (m_TimeUpTextDisplayTime < 0)
        {
            SceneManager.LoadScene("Result");
        }
    }

    public void TimeUp()
    {
        m_IsTimeUp = true;
        m_Text.gameObject.SetActive(true);
    }
}
