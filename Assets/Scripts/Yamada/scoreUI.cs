using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    int Score ;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }
    public void AddScore(int addScore)
    {
        Score = Score  + addScore;
        if (Score > 9999)
        {
            text.text = "9999";
        }
        else
        {
            text.text = Score.ToString();
        }
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    AddScore(1);
    //}
}
