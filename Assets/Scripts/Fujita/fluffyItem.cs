using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fluffyItem : MonoBehaviour
{
	// �ϐ���錾
	[Header("�A�C�e���̌������Z��")] public float fAddRotation = 0.0f;	// �A�C�e���������Z��
	[Header("�A�C�e���̏c�ʒu���Z��")] public float fAddSinRot = 0.0f;	// �A�C�e���ʒu���Z��

	private float fSinRot = 0.0f;	// �c�ʒu���Z�p�̃T�C���J�[�u

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// �ϐ���錾
		Vector3 pos = transform.position;	// �ʒu
		Vector3 rot = transform.rotation.eulerAngles;  // ����

		// �ʒu�����Z
		pos.y += fAddSinRot;

		// ���������Z
		rot.y += fAddRotation;

		// �����𔽉f
		transform.rotation = Quaternion.Euler(rot);
	}
}
