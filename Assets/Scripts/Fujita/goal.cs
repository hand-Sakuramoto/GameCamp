using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
	// �����o�ϐ���錾
	private int m_nNumMint = 0; // �~���g�̑���

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	// �����蔻��
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{ // �v���C���[�̏ꍇ

			// �f�o�b�O�\��
			Debug.Log("Hit");
		}
	}

	// �~���g�[�i���̉��Z
	void AddNumMint(int nAddMint)
	{
		// �����̃~���g���Z�ʂ����Z
		m_nNumMint += nAddMint;
	}
}
