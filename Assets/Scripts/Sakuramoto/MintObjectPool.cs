using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MintObjectPool : ObjectPool<MintObject>
{
    [SerializeField]
    private List<MintObject> m_ActiveList;

    [SerializeField]
    private int m_InitializeCount = 500;

	[SerializeField]
	public PlayerScripts PS;    // プレイヤースクリプト

	public int nCounterCreate = 0;	// 生成数

	private void Awake()
    {
        Setup(m_InitializeCount);
    }

    private void Update()
    {

	}

	// 生成
	public void Create()
	{
		MintObject mintObject = Get();
		m_ActiveList.Add(mintObject);

		// 変数を宣言
		float fScale = (PS.GetComponent<PlayerScripts>().Uekibachi.transform.localScale.x - PS.GetComponent<PlayerScripts>().InitialUekibachiSize) * 0.025f;
		if (fScale < 1.0f)
		{
			// 拡大率を補正
			fScale = 1.0f;
		}

		float fRandX = Random.Range(-0.5f * fScale, 0.5f * fScale);	// X座標ランダム
		float fRandZ = Random.Range(-0.5f * fScale, 0.5f * fScale);	// Z座標ランダム
		Vector3 posPlayer = PS.GetComponent<PlayerScripts>().gameObject.transform.position;			// プレイヤー位置
		Vector3 posRandom = new Vector3(fRandX, 2.2f + (nCounterCreate * 0.025f / fScale), fRandZ);	// ランダム加算位置
		Vector3 posMint = posPlayer + posRandom;	// 表示位置

		// 位置の設定
		mintObject.transform.position = posMint;

		// 向きの設定
		mintObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, Random.Range(0.0f, 360.0f), 270.0f));

		// 生成数を加算
		nCounterCreate++;
	}

	// 破棄
	public void Release()
	{
		// 変数を宣言
		int nReleaseID = m_ActiveList.Count - 1;	// 削除インデックス

		// 所持数の確認
		if (m_ActiveList.Count <= 0) { return; }

		// 破棄
		MintObject mintObject = m_ActiveList[nReleaseID];
		m_ActiveList.RemoveAt(nReleaseID);
		Release(mintObject);

		// 生成数を減算
		nCounterCreate--;
	}

	// 全破棄
	public void ReleaseAll()
	{
		// 生成数を初期化
		nCounterCreate = 0;

		// 所持数の確認
		while (m_ActiveList.Count > 0)
		{ // 残っている場合繰り返す

			// 破棄
			MintObject mintObject = m_ActiveList[0];
			m_ActiveList.RemoveAt(0);
			Release(mintObject);
		}
	}
}