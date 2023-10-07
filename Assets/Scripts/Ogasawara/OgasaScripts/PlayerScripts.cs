using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScripts : MonoBehaviour
{
    [Header("プレイヤー移動速度")] public float PlayerSpeed;
    [Header("持っているミントの数")] public float MintNum = 0;
    [Header("プレイヤーの体力")] public int PlayerHP;

    [Header("ミントが自動で増えるまでの時間")] public float AutoMintNumUpTime;

    [Header("自動ミントが増える量")] public float MintUpNum;

    [Header("持っている植木鉢の破片の数")] public float UekibatiNum;
    [Header("植木鉢強化までの破片数")] public float UekibatiPowerUpCountMax;


    private Rigidbody rb; //RigidBody宣言　(10/7 12:22)

    private float AutoMintNumUpTimeNow;

    private int PlayableNum = 0; //変数によるプレイヤー操作可能タイミング制限（0が操作可能、1が準備、ゲーム終了時など操作不能時）

    [Header("持っているミント数の仮のテキスト表示")] public TextMeshProUGUI MintTextBeta;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();


        AutoMintNumUpTimeNow = AutoMintNumUpTime;

        MintTextBeta.text = "MintNum:" + MintNum;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayableNum == 0)
        {
            //移動処理(10/7 12:39)
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                rb.velocity = transform.right * PlayerSpeed;
            }

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                rb.velocity = transform.right * -PlayerSpeed;
            }

            if (Input.GetAxisRaw("Vertical") > 0)
            {
                rb.velocity = transform.forward * PlayerSpeed;
            }

            if (Input.GetAxisRaw("Vertical") < 0)
            {
                rb.velocity = transform.forward * -PlayerSpeed;
            }

            //移動キーニュートラルで止まる(10/7 13:06)
            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                rb.velocity = Vector3.zero;
            }


            //移動ここまで

            //自動で持っているミント数が増える処理
            if(AutoMintNumUpTimeNow > 0)
            {
                AutoMintNumUpTimeNow--;
                if(AutoMintNumUpTimeNow <= 0)
                {
                    AutoMintNumUpTimeNow = AutoMintNumUpTime;
                    MintNum += MintUpNum;

                    //ミント数の仮表示(10/7 13:16)
                    MintTextBeta.text = "MintNum:" + MintNum;
                }
            }
        }
    }


   
}
