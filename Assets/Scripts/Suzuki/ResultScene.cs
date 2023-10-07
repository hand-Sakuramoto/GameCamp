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

    private int score1 = 0;
    private int score2 = 0;
    private int score3 = 0;
    private int score4 = 0;
    private int score5 = 0;

    // Start is called before the first frame update
    void Start()
    {
    
      //ランキングの書き換えをここでする。
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
