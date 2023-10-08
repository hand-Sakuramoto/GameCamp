using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitileScene : MonoBehaviour
{

    public AudioClip sound;
    private AudioSource audioSource;

	[SerializeField] public GameObject m_objFade;		// フェード
	[SerializeField] public GameObject m_objTutorial;	// チュートリアル

	private bool m_bTutorial = false;	// チュートリアル表示状況

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			// チュートリアルを切り替え
			EnableDrawTutorial((!m_bTutorial) ? true : false);
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{
			if (m_bTutorial)
			{
				// チュートリアルを切り替え
				EnableDrawTutorial((!m_bTutorial) ? true : false);
			}
			else
			{ // チュートリアル状況ではない場合

				audioSource.PlayOneShot(sound); // SEを鳴らす
				Invoke("ChangeScene", 0.50f);   // シーンをまたぐとSEが破棄され、途切れるため、少し待つ対処をとる。
			}
		}
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Main");//メインシーンに遷移させる
    }

	void EnableDrawTutorial(bool bDraw)
	{
		// チュートリアルの表示状況を切り替え
		m_bTutorial = bDraw;

		if (m_bTutorial)
		{ // 表示する場合

			m_objFade.SetActive(true);
			m_objTutorial.SetActive(true);
		}
		else
		{ // 表示しない場合

			m_objFade.SetActive(false);
			m_objTutorial.SetActive(false);
		}
	}
}
