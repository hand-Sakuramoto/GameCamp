using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
	// �����o�ϐ���錾
	[SerializeField] public float fGoalRadius = 0.0f;	// �S�[������̔��a

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
		// �f�o�b�O�\��
		Debug.Log("Hit");
	}
}
