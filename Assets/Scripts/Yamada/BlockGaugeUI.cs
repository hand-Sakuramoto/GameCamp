using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockGaugeUI : SingletonMonoBehaviour<BlockGaugeUI>
{
    protected override bool IsDontDestroyOnLoad { get { return false; } }

    [SerializeField]
    Image BlockGauge;
    [SerializeField]
    int MaxBlockCount = 100;
    [SerializeField]
    int CurrentBlockCount = 0;
    // Start is called before the first frame update
    public void SetBlockCount(int blockCount, int maxBlockCount)
    {
        BlockGauge.fillAmount = blockCount / (float)maxBlockCount;
    }
    void Start()
    {
        
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    SetBlockCount(CurrentBlockCount, MaxBlockCount);
    //}
}
