using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MintGaugeUI : MonoBehaviour
{
    [SerializeField]
    Slider MintGauge;
    [SerializeField]
    int MaxMintCount = 100;
    [SerializeField]
    int CurrentMintCount = 0;

    // Start is called before the first frame update
    public void SetMintCount(int mintCount,int maxMintCount)
    {
        MintGauge.value = mintCount / (float)maxMintCount;
    }
    void Start()
    {

    }

    //// Update is called once per frame
    //void Update()
    //{
    //    SetMintCount(CurrentMintCount,MaxMintCount);
    //}
}