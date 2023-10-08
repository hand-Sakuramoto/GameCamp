using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MintObjectPool : ObjectPool<MintObject>
{
    [SerializeField]
    private List<MintObject> m_ActiveList;

    [SerializeField]
    private int m_InitializeCount = 500;

	[SerializeField]
	public PlayerScripts PS;    // �v���C���[�X�N���v�g

	public int nCounterCreate = 0;	// ������

    public AudioClip sound;
    private AudioSource audioSource;

	private void Awake()
    {
        Setup(m_InitializeCount);
		audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

	}

	// ����
	public void Create()
	{
		MintObject mintObject = Get();
		m_ActiveList.Add(mintObject);

		// �ϐ���錾
		float fScale = (PS.GetComponent<PlayerScripts>().Uekibachi.transform.localScale.x - PS.GetComponent<PlayerScripts>().InitialUekibachiSize) * 0.025f;
		if (fScale < 1.0f)
		{
			// �g�嗦��␳
			fScale = 1.0f;
		}

		float fRandX = Random.Range(-0.5f * fScale, 0.5f * fScale);	// X���W�����_��
		float fRandZ = Random.Range(-0.5f * fScale, 0.5f * fScale);	// Z���W�����_��
		Vector3 posPlayer = PS.GetComponent<PlayerScripts>().gameObject.transform.position;			// �v���C���[�ʒu
		Vector3 posRandom = new Vector3(fRandX, 2.2f + (nCounterCreate * 0.025f / fScale), fRandZ);	// �����_�����Z�ʒu
		Vector3 posMint = posPlayer + posRandom;	// �\���ʒu

		//SE��炷
		audioSource.PlayOneShot(sound);

		// �ʒu�̐ݒ�
		mintObject.transform.position = posMint;

		// �����̐ݒ�
		mintObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, Random.Range(0.0f, 360.0f), 270.0f));

		// ����������Z
		nCounterCreate++;
	}

	// �j��
	public void Release()
	{
		// �ϐ���錾
		int nReleaseID = m_ActiveList.Count - 1;	// �폜�C���f�b�N�X

		// �������̊m�F
		if (m_ActiveList.Count <= 0) { return; }

		// �j��
		MintObject mintObject = m_ActiveList[nReleaseID];
		m_ActiveList.RemoveAt(nReleaseID);
		Release(mintObject);

		// ����������Z
		nCounterCreate--;
	}

	// �S�j��
	public void ReleaseAll()
	{
		// �������������
		nCounterCreate = 0;

		// �������̊m�F
		while (m_ActiveList.Count > 0)
		{ // �c���Ă���ꍇ�J��Ԃ�

			// �j��
			MintObject mintObject = m_ActiveList[0];
			m_ActiveList.RemoveAt(0);
			Release(mintObject);
		}
	}
}