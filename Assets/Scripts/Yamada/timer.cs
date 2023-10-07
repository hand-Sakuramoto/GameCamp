using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    float RemainingTime = 180;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (RemainingTime > 0)
        {
            RemainingTime = RemainingTime - Time.deltaTime;
            if (RemainingTime <= 0)
            {
                RemainingTime = 0;
            }
            text.text = RemainingTime.ToString("F2");
        }
    }
}
