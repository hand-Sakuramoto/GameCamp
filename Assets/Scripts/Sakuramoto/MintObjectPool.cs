using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MintObjectPool : ObjectPool<MintObject>
{
    [SerializeField]
    private List<MintObject> m_ActiveList;

    [SerializeField]
    private int m_InitializeCount = 10;

	[SerializeField]
	public PlayerScripts PS;    // プレイヤースクリプト

	private void Awake()
    {
        Setup(m_InitializeCount);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
			// 生成
			Create();
        }

        if (Input.GetKeyUp(KeyCode.Backspace))
        {
			// 破棄
			Release();
        }
    }

	// 生成
	private void Create()
	{
		MintObject mintObject = Get();
		m_ActiveList.Add(mintObject);

		// 変数を宣言
		Vector3 posPlayer = PS.GetComponent<PlayerScripts>().gameObject.transform.position;
		Vector3 posRandom = new Vector3(Random.Range(-0.5f, 0.5f), 2.5f + (m_ActiveList.Count * 0.025f), Random.Range(-0.5f, 0.5f));
		Vector3 posMint = posPlayer + posRandom;

		// 位置の設定
		mintObject.transform.position = posMint;

		// 向きの設定
		mintObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, Random.Range(0.0f, 360.0f), 270.0f));
	}

	// 破棄
	public void Release()
	{
		if (m_ActiveList.Count <= 0) { return; }

		MintObject mintObject = m_ActiveList[0];
		m_ActiveList.RemoveAt(0);
		Release(mintObject);
	}
}