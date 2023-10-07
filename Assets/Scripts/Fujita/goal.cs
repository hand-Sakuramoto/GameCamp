using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
	// メンバ変数を宣言
	private int m_nNumMint = 0; // ミントの総数

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	// 当たり判定
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{ // プレイヤーの場合

			// デバッグ表示
			Debug.Log("Hit");

			// プレイヤーの所持ミント数を加算
			int addMintNum = other.gameObject.GetComponent<PlayerScripts>().MintNum;

            scoreUI.Instance.AddScore(addMintNum);

            m_nNumMint += addMintNum;

            // 所持ミント数をリセット
            other.gameObject.GetComponent<PlayerScripts>().MintReturn();
		}
	}
}
