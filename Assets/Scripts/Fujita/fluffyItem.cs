using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fluffyItem : MonoBehaviour
{
	// �ϐ���錾
	[Header("�A�C�e���̌������Z��")] public float fRotationSpeed = 0.0f;	// �A�C�e���������Z��

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// �ϐ���錾
		Vector3 rot = transform.rotation.eulerAngles;  // ����

		// ���������Z
		rot.y += Time.deltaTime * fRotationSpeed;

		// �����𔽉f
		transform.rotation = Quaternion.Euler(rot);
	}
}
