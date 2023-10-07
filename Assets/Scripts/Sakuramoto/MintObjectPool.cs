using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MintObjectPool : ObjectPool<MintObject>
{
    [SerializeField]
    private List<MintObject> m_ActiveList;

    [SerializeField]
    private int m_InitializeCount = 10;

    int count;

    private void Awake()
    {
        Setup(m_InitializeCount);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MintObject mintObject = Get();
            m_ActiveList.Add(mintObject);
            mintObject.transform.position = new Vector2(count, 0);
            count++;
        }

        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            if (m_ActiveList.Count <= 0) { return; }

            MintObject mintObject = m_ActiveList[0];
            m_ActiveList.RemoveAt(0);
            Release(mintObject);
        }
    }
}