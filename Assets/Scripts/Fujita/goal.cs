using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
	// メンバ変数を宣言
	[SerializeField] public float fGoalRadius = 0.0f;	// ゴール判定の半径

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

	}

	// 当たり判定
	void OnCollisionEnter(Collision collision)
	{
		// デバッグ表示
		Debug.Log("Hit");
	}
}
