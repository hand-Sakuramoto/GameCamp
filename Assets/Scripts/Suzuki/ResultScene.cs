using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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
    public AudioClip sound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
      audioSource = GetComponent<AudioSource>();

      //過去スコアの読み出し
      int score1 = PlayerPrefs.GetInt("score1");
      int score2 = PlayerPrefs.GetInt("score2");
      int score3 = PlayerPrefs.GetInt("score3");
      int score4 = PlayerPrefs.GetInt("score4");
      int score5 = PlayerPrefs.GetInt("score5");

      int score = PlayerPrefs.GetInt("ResultScore");
      Debug.Log(score);

      //同一順位でランキングが埋まらないように処理をスキップ
      if(score == score1){goto label;}
      if(score == score2){goto label;}
      if(score == score3){goto label;}
      if(score == score4){goto label;}
      if(score == score5){goto label;}


      //順位に並べる
      if (score1 < score)
        {
            score5 = score4;
            score4 = score3;
            score3 = score2;
            score2 = score1;
            score1 = score;
        }
        else if (score2 < score)
        {
            score5 = score4;
            score4 = score3;
            score3 = score2;
            score2 = score;
        }else if (score3 < score)
        {
            score5 = score4;
            score4 = score3;
            score3 = score;
        }else if (score4 < score)
        {
            score5 = score4;
            score4 = score;
        }else if (score5 < score)
        {
            score5 = score;
        }
        else
        {

        };
    label:

      //新しい値のセット
      PlayerPrefs.SetInt("score1", score1);
      PlayerPrefs.SetInt("score2", score2);
      PlayerPrefs.SetInt("score3", score3);
      PlayerPrefs.SetInt("score4", score4);
      PlayerPrefs.SetInt("score5", score5);
      PlayerPrefs.Save();

      //ランキングの表示換えをここでする。
      ScoreText1.text =  score1.ToString();
      ScoreText2.text =  score2.ToString();
      ScoreText3.text =  score3.ToString();
      ScoreText4.text =  score4.ToString();
      ScoreText5.text =  score5.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey){
           audioSource.PlayOneShot(sound);//SEを鳴らす
           Invoke("ChangeScene", 0.30f);//シーンをまたぐとSEが破棄され、途切れるため、少し待つ対処をとる。
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
