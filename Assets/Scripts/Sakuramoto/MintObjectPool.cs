using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MintObjectPool : ObjectPool<MintObject>
{
    [SerializeField]
    private List<MintObject> m_ActiveList;

    [SerializeField]
    private int m_InitializeCount = 10;

	[SerializeField]
	public PlayerScripts PS;    // �v���C���[�X�N���v�g

	private void Awake()
    {
        Setup(m_InitializeCount);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
			// ����
			Create();
        }

        if (Input.GetKeyUp(KeyCode.Backspace))
        {
			// �j��
			Release();
        }
    }

	// ����
	private void Create()
	{
		MintObject mintObject = Get();
		m_ActiveList.Add(mintObject);

		// �ϐ���錾
		Vector3 posPlayer = PS.GetComponent<PlayerScripts>().gameObject.transform.position;
		Vector3 posRandom = new Vector3(Random.Range(-0.5f, 0.5f), 2.5f + (m_ActiveList.Count * 0.025f), Random.Range(-0.5f, 0.5f));
		Vector3 posMint = posPlayer + posRandom;

		// �ʒu�̐ݒ�
		mintObject.transform.position = posMint;

		// �����̐ݒ�
		mintObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, Random.Range(0.0f, 360.0f), 270.0f));
	}

	// �j��
	public void Release()
	{
		if (m_ActiveList.Count <= 0) { return; }

		MintObject mintObject = m_ActiveList[0];
		m_ActiveList.RemoveAt(0);
		Release(mintObject);
	}
}