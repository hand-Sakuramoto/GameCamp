using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potPiece : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// �����蔻��
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{ // �v���C���[�̏ꍇ

			// �f�o�b�O�\��
			Debug.Log("�A�ؔ��̂�����Hit");

			// ���g��j��
			Destroy(collision.gameObject);
		}
	}
}
