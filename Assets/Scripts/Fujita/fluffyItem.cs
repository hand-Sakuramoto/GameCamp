using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fluffyItem : MonoBehaviour
{
	// 変数を宣言
	[Header("アイテムの向き加算量")] public float fAddRotation = 0.0f;	// アイテム向き加算量

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// 変数を宣言
		Vector3 rot = transform.rotation.eulerAngles;  // 向き

		// 向きを加算
		rot.y += fAddRotation;

		// 向きを反映
		transform.rotation = Quaternion.Euler(rot);
	}
}
