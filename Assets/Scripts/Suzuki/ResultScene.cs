using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScene : MonoBehaviour
{
    public Text timeTexts;
    float totalTime = 60;
    int retime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        retime = (int)totalTime;
        timeTexts.text = retime.ToString();
        if(retime == 0)
        {
            SceneManager.LoadScene("resolt");
        }
    }

/*MainScene上に増設
using UnityEngine.SceneManagement;
    void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
    }

*/

}
