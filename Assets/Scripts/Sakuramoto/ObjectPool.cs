using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    private List<T> m_CanUseList = new List<T>();
    [SerializeField]
    private List<T> m_UsedList = new List<T>();

    [SerializeField]
    protected T m_Prefab;

    public void Setup(int initializeCount)
    {
        for (int i = 0; i < initializeCount; i++)
        {
            m_CanUseList.Add(Generate());
        }
    }

    public T Get()
    {
        T testObject;
        if (m_CanUseList.Count != 0)
        {
            testObject = m_CanUseList[0];
            m_CanUseList.RemoveAt(0);
        }
        else
        {
            testObject = Generate();
        }
        testObject.gameObject.SetActive(true);
        m_UsedList.Add(testObject);
        return testObject;
    }

    public void Release(T testObject)
    {
        if (m_UsedList.Contains(testObject))
        {
            m_UsedList.Remove(testObject);
        }

        m_CanUseList.Add(testObject);
        testObject.gameObject.SetActive(false);
    }

    private T Generate()
    {
        T testObject;
        testObject = GameObject.Instantiate<T>(m_Prefab, this.gameObject.transform);
        testObject.gameObject.SetActive(false);
        return testObject;
    }
}
