using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	// �����o�ϐ���錾
	[SerializeField] public Object thisObject;	// ���g�̃I�u�W�F�N�g

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
			Debug.Log("�h�{��Hit");

			// ���g��j��
			Destroy(thisObject);
		}
	} 
}
