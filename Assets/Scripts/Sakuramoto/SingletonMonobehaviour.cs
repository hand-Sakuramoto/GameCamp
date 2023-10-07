using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    protected abstract bool IsDontDestroyOnLoad { get; }

    private static T m_instance;
    public static T Instance
    {
        get
        {
            if (!m_instance)
            {
                Type t = typeof(T);
                m_instance = (T)FindObjectOfType(t);
                if (!m_instance)
                {
                    Debug.LogError(t + " is nothing.");
                }
            }
            return m_instance;
        }
    }

    protected virtual void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }
        if (IsDontDestroyOnLoad)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}