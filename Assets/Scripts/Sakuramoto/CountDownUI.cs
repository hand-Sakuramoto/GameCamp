using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI m_Text;

    [SerializeField]
    float m_StartTextDisplayTime = 0.5f;

    float m_CountDownTimer = 3;

    bool m_IsCountDown = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (m_IsCountDown)
        {
            m_CountDownTimer -= Time.deltaTime;

            if (m_CountDownTimer < 0)
            {
                m_Text.text = "Start!";
                m_IsCountDown = false;
            }
            else if (m_CountDownTimer < 1)
            {
                m_Text.text = "1";
            }
            else if (m_CountDownTimer < 2)
            {
                m_Text.text = "2";
            }
            else
            {
                m_Text.text = "3";
            }
        }
        else
        {
            m_StartTextDisplayTime -= Time.deltaTime;

            if (m_StartTextDisplayTime < 0)
            {
                m_Text.gameObject.SetActive(false);
                GameManager.Instance.GameStart();
                //this.enabled = false;
            }
        }
    }
}
