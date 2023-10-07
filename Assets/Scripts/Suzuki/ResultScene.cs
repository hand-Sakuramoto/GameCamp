using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScene : MonoBehaviour
{
    public Text timeTexts;
    //float totalTime = 60;
    int retime;
    public TMPro.TextMeshProUGUI ScoreText1;
    public TMPro.TextMeshProUGUI ScoreText2;
    public TMPro.TextMeshProUGUI ScoreText3;
    public TMPro.TextMeshProUGUI ScoreText4;
    public TMPro.TextMeshProUGUI ScoreText5;

    // Start is called before the first frame update
    void Start()
    {
      //過去スコアの読み出し
      int score1 = PlayerPrefs.GetInt("score1");
      int score2 = PlayerPrefs.GetInt("score2");
      int score3 = PlayerPrefs.GetInt("score3");
      int score4 = PlayerPrefs.GetInt("score4");
      int score5 = PlayerPrefs.GetInt("score5");  

      //順位に並べる
      




      //新しい値のセット
      //PlayerPrefs.SetInt("score1", 0);
      //PlayerPrefs.SetInt("score2", 0);
      //PlayerPrefs.SetInt("score3", 0);
      //PlayerPrefs.SetInt("score4", 0);
      //PlayerPrefs.SetInt("score5", 0);
      //PlayerPrefs.Save();


      //ランキングの表示換えをここでする。
      ScoreText1.text = "1位　" + score1.ToString();
      ScoreText2.text = "2位　" + score2.ToString();
      ScoreText3.text = "3位　" + score3.ToString();
      ScoreText4.text = "4位　" + score4.ToString();
      ScoreText5.text = "5位　" + score5.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey){
           //audioSource.PlayOneShot(sound);//SEを鳴らす
           Invoke("ChangeScene", 0.25f);//シーンをまたぐとSEが破棄され、途切れるため、少し待つ対処をとる。
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Title");//メインシーンに遷移させる
    }

/*MainScene上に増設
using UnityEngine.SceneManagement;
    void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
    }

*/
        /*
        totalTime -= Time.deltaTime;
        retime = (int)totalTime;
        timeTexts.text = retime.ToString();
        if(retime == 0)
        {
            SceneManager.LoadScene("resolt");
        }
        */
}
