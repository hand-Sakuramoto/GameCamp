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

			// �v���C���[�̏����~���g�������Z
			m_nNumMint += (int)other.gameObject.GetComponent<PlayerScripts>().MintNum;

			// �����~���g�������Z�b�g
			other.gameObject.GetComponent<PlayerScripts>().MintReturn();
		}
	}
}
