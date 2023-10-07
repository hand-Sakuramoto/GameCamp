using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    public Text ScoreText;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = TargetGene.getscore();
        score = PlayerPrefs.GetInt("ResultScore");
        ScoreText.text = string.Format("Score:{0}", score)+"本";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
