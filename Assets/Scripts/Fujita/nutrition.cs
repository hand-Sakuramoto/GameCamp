using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nutrition : MonoBehaviour
{
	// メンバ変数を宣言
	[SerializeField] public Object thisObject;	// 自身のオブジェクト
	[SerializeField] public PlayerScripts PS;	// プレイヤープレハブ

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
			Debug.Log("栄養剤Hit");

			// 自身を破棄
			Destroy(thisObject);

			// 栄養剤バフによるミント増殖スピードアップ
			PS.AutoMintUpSpeedUp();
		}
	}
}
