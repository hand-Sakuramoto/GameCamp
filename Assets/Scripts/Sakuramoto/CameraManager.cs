using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Camera m_Camera;

    [SerializeField]
    Vector3 m_Offset = Vector3.zero;

    PlayerScripts m_PlayerScripts;

    private void Awake()
    {
        m_Camera = Camera.main;
    }

    private void Start()
    {
        m_PlayerScripts = PlayerScripts.Instance;
        m_Camera.transform.position = m_PlayerScripts.transform.position + m_Offset;
    }

    void Update()
    {
        m_Camera.transform.position = Vector3.Lerp(m_Camera.transform.position, m_PlayerScripts.transform.position + m_Offset, 6.0f * Time.deltaTime);
    }
}
