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
      ScoreText1.text = "11";
      ScoreText2.text = "11";
      ScoreText3.text = "11";
      ScoreText4.text = "11";
      ScoreText5.text = "11";
    }

    // Update is called once per frame
    void Update()
    {
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

/*MainScene上に増設
using UnityEngine.SceneManagement;
    void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
    }

*/

}
