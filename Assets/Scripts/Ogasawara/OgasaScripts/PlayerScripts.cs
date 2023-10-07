using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScripts : MonoBehaviour
{
    [Header("プレイヤー移動速度")] public float PlayerSpeed;
    [Header("プレイヤー移動速度の下限")] public float MinPlayerSpeed;

    [Header("プレイヤースピード減少補正係数(小さければ小さいほど抑制力強)")] public float PlayerSpeedDownCorrection;

    [Header("持っているミントの数")] public float MintNum = 0;
    [Header("プレイヤーの体力")] public int PlayerHP;

    [Header("ミント最大保持数")] public float MintNumMaxCount = 100; 

    [Header("ミントが自動で増えるまでの時間")] public float AutoMintNumUpTime;

    [Header("自動でミントが増える量")] public float MintUpNum;

    [Header("栄養剤バフの効果時間")] public float EiyouzaiBuffTime;

    [Header("栄養剤バフの効果時間増加量")] public float EiyouzaiBuffUpCount;


    [Header("栄養剤バフ中のミントが増える時間の減少量")]public float AutoMintNumTimeBuffCount;

    [Header("ミントが自動で増えるまでの時間の初期値")]public float InitialAutoMintNumUpTime;

    [Header("持っている植木鉢の破片の数")] public float UekibatiNum;
    [Header("植木鉢強化までの破片数")] public float UekibatiPowerUpCountMax;

    [Header("障害物にヒット時のダメージ量")] public float Damage;


    private Rigidbody rb; //RigidBody宣言　(10/7 12:22)

    private float AutoMintNumUpTimeNow;//現在のミントが自動で増えるまでの時間　(10/7 13:47)

    private int PlayableNum = 0; //変数によるプレイヤー操作可能タイミング制限（0が操作可能、1が準備、ゲーム終了時など操作不能時）

    private bool isEiyouzaiBuff = false; //栄養剤バフ中かどうかの切り替え変数　(10/7 15:04)

    //[Header("持っているミント数の仮のテキスト表示")] public TextMeshProUGUI MintTextBeta;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        ///ミントが自動で増えるまでの時間の初期化　(10/7 13:47)
        InitialAutoMintNumUpTime = AutoMintNumUpTime;
        AutoMintNumUpTimeNow = AutoMintNumUpTime;

        //MintTextBeta.text = "MintNum:" + MintNum;
    }

    // Update is called once per frame
    void Update()
    {
        //移動処理(10/7 12:39)
        if (PlayableNum == 0)
        {
            
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                rb.velocity = new Vector3(PlayerSpeed,0,0);
            }

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                rb.velocity = new Vector3(-PlayerSpeed, 0, 0);
            }

            if (Input.GetAxisRaw("Vertical") > 0)
            {
                rb.velocity = new Vector3(0, 0, PlayerSpeed);
            }

            if (Input.GetAxisRaw("Vertical") < 0)
            {
                rb.velocity = new Vector3(0, 0, -PlayerSpeed);
            }

            //移動キーニュートラルで止まる(10/7 13:06)
            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                rb.velocity = Vector3.zero;
            }


            //移動ここまで

            //ミント処理
            MintFunction();

            //ミント数依存のスピードダウン処理へ
            MintSpeedDown();


        }
    }

    

    //持っているミントの処理一覧関数(10:07 16:18)
    private void MintFunction()
    {
        //自動で持っているミント数が増える処理
        if (AutoMintNumUpTimeNow > 0)
        {
            AutoMintNumUpTimeNow--;
            if (AutoMintNumUpTimeNow <= 0)
            {
                AutoMintNumUpTimeNow = AutoMintNumUpTime;
                MintNum += MintUpNum;

                //持っているミント数の上限設定
                if (MintNum >= MintNumMaxCount)
                {
                    MintNum = MintNumMaxCount;
                }

                //ミント数の仮表示(10/7 13:16)
                //MintTextBeta.text = "MintNum:" + MintNum;
            }
        }

        //栄養剤バフ中の制限時間処理(10/7 15:22)
        if (isEiyouzaiBuff)
        {
            if (EiyouzaiBuffTime > 0)
            {
                EiyouzaiBuffTime--;

                //栄養剤バフの効果時間が０になったら効果制限時間リセット
                if (EiyouzaiBuffTime <= 0)
                {
                    isEiyouzaiBuff = false;
                    EiyouzaiBuffTime = 0;
                    AutoMintNumUpTime = InitialAutoMintNumUpTime;

                }
            }
        }
    }

    //持っているミント数でのスピードダウン処理(10/7 16:03)
    private void MintSpeedDown()
    {
        if(MintNum > 0　&& MintNum < MintNumMaxCount)
        {
            PlayerSpeed = PlayerSpeed - PlayerSpeed * PlayerSpeedDownCorrection * MintNum / MintNumMaxCount;
            if (PlayerSpeed <= 0)
            {
                PlayerSpeed = MinPlayerSpeed;
            }
        }
        
    }


    //植木鉢の破片を獲得した処理(10/7 13:45)
    public void UekibatiCountUp()
    {
        UekibatiNum += 1;

        //破片を全部取った時に植木鉢強化(10/7 13:46)
        if (UekibatiNum >= UekibatiPowerUpCountMax)
        {

            UekibatiNum = 0;
        }
    }
    //栄養剤バフによるミント増殖スピードアップ処理(10/7 15:02)
    public void AutoMintUpSpeedUp()
    {
        
        EiyouzaiBuffTime += EiyouzaiBuffUpCount;

        AutoMintNumUpTime -= AutoMintNumTimeBuffCount;

        isEiyouzaiBuff = true;

    }

    //障害物に当たった時のミント数、体力減少処理(10/7 15:41)
    public void HitDamage()
    {
        //ミントを持っていたらミントを減少
        if(MintNum > 0 && PlayerHP > 0)
        {
            MintNum -= Damage;

            if(MintNum <= 0)
            {
                MintNum = 0;
            }

            
        }
        /*
        //ミントを持っていなかったらプレイヤーの体力減少
        else if(MintNum <= 0 && PlayerHP > 0)
        {
            PlayerHP -= 1;
            if(PlayerHP <= 0)
            {
                PlayerHP = 0;
                //プレイヤー一定時間行動不能処理
            }
        }*/
    }

    
    //持っているミントを拠点へ返した時の処理(10/7 16:47)
    public void MintReturn()
    {
        MintNum = 0;
    }
    
}
