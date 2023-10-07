using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestObjectPool : ObjectPool<TestObject>
{
    [SerializeField]
    private List<TestObject> m_ActiveList;

    [SerializeField]
    private int m_InitializeCount = 10;

    int count;

    private void Awake()
    {
        Setup(m_InitializeCount);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TestObject testObject = Get();
            m_ActiveList.Add(testObject);
            testObject.transform.position = new Vector2(count, 0);
            count++;
        }

        if(Input.GetKeyUp(KeyCode.Backspace))
        {
            if(m_ActiveList.Count <= 0) { return; }

            TestObject testObject = m_ActiveList[0];
            m_ActiveList.RemoveAt(0);
            Release(testObject);
        }
    }
}
