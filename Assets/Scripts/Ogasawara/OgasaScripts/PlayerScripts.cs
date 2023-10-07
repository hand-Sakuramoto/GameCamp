using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScripts : SingletonMonoBehaviour<PlayerScripts>
{
    protected override bool IsDontDestroyOnLoad { get { return false; } }


    [Header("プレイヤー移動速度")] public float PlayerSpeed;
    [Header("プレイヤー移動速度の下限")] public float MinPlayerSpeed;
    [Header("プレイヤー移動速度初期値")]public float InitialPlayerSpeed;
    [Header("プレイヤー回転スピード")] public float rotationSpeed = 360;


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

    [Header("植木鉢")] public GameObject Uekibachi;

    [Header("植木鉢の大きさの初期値")]public float InitialUekibachiSize;

    [Header("植木鉢のスケール巨大化係数")] public float UekibachiGiantSize;

    private Rigidbody rb; //RigidBody宣言　(10/7 12:22)

    private float AutoMintNumUpTimeNow;//現在のミントが自動で増えるまでの時間　(10/7 13:47)

    private int PlayableNum = 1; //変数によるプレイヤー操作可能タイミング制限（0が操作可能、1が準備、ゲーム終了時など操作不能時）

    private bool isEiyouzaiBuff = false; //栄養剤バフ中かどうかの切り替え変数　(10/7 15:04)

    private Vector3 latestPos; //前回のポジション(10/8 0:08)

    //[Header("持っているミント数の仮のテキスト表示")] public TextMeshProUGUI MintTextBeta;

	[SerializeField] public MintObjectPool m_mintPool;	// ミント生成オブジェクト


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        ///ミントが自動で増えるまでの時間の初期化　(10/7 13:47)
        InitialAutoMintNumUpTime = AutoMintNumUpTime;
        AutoMintNumUpTimeNow = AutoMintNumUpTime;

        //移動速度の初期化
        PlayerSpeed = InitialPlayerSpeed;

        //植木鉢の大きさの初期化
        Vector3 localScale = Uekibachi.transform.localScale;
        localScale.x = InitialUekibachiSize;
        localScale.y = InitialUekibachiSize;
        localScale.z = InitialUekibachiSize;
        Uekibachi.transform.localScale = localScale;

        
        //MintTextBeta.text = "MintNum:" + MintNum;
    }

    // Update is called once per frame
    void Update()
    {
        //移動処理+移動方向にキャラクターの正面を向かわせる(10/8 0:33更新)
        if (PlayableNum == 0)
        {
            
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                rb.velocity += new Vector3(PlayerSpeed,0,0);
            }

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                rb.velocity += new Vector3(-PlayerSpeed, 0, 0);
            }

            if (Input.GetAxisRaw("Vertical") > 0)
            {
                rb.velocity += new Vector3(0, 0, PlayerSpeed);
            }

            if (Input.GetAxisRaw("Vertical") < 0)
            {
                rb.velocity += new Vector3(0, 0, -PlayerSpeed);
            }

            //移動した方向に向きを変える
            if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                //前回からどこに進んだかをベクトルで取得(10/08 1:26)
                Vector3 diff = transform.position - latestPos;
                //前回のPositionの更新(10/08 1:26)
                latestPos = transform.position;

                //ベクトルの大きさ0.01以上で向きを変える処理へ(10/08 1:37)
                if (diff.magnitude > 0.01f)
                {
                    transform.rotation = Quaternion.LookRotation(diff);//向き変更
                }
            }
            



            //移動キーニュートラルで止まる(10/7 13:06)
            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                rb.velocity = Vector3.zero;
            }




            //移動ここまで

            //ミント処理
            MintFunction();

            


        }
    }

    

    //持っているミントの処理一覧関数(10:07 16:18)
    private void MintFunction()
    {
        //自動で持っているミント数が増える処理
        if (AutoMintNumUpTimeNow > 0)
        {
            AutoMintNumUpTimeNow-= Time.deltaTime;
            if (AutoMintNumUpTimeNow <= 0)
            {
                AutoMintNumUpTimeNow = AutoMintNumUpTime;
                MintNum += MintUpNum;

                //ミント数依存のスピード変化処理へ
                MintSpeedChange();

                //持っているミント数の上限設定
                if (MintNum >= MintNumMaxCount)
                {
                    MintNum = MintNumMaxCount;
                }

                // Debug.Log(MintNum);
                //ミント数の仮表示(10/7 13:16)
                //MintTextBeta.text = "MintNum:" + MintNum;
            }
        }

        //栄養剤バフ中の制限時間処理(10/7 15:22)
        if (isEiyouzaiBuff)
        {
            if (EiyouzaiBuffTime > 0)
            {
                EiyouzaiBuffTime -= Time.deltaTime;

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

    //持っているミント数でのスピード変化処理(10/7 16:03)
    private void MintSpeedChange()
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
            UekibachiGiantMode();
			m_mintPool.nCounterCreate = 0;	// 生成高度を初期化
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
        //ダメージを受けた時、ミントを持っていたらミントを減少＋栄養剤バフ強制終了
        if(MintNum > 0 && PlayerHP > 0)
        {
            MintNum -= Damage;

            EiyouzaiBuffTime = 0;

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

        //プレイヤー移動速度リセット
        PlayerSpeed = InitialPlayerSpeed;
    }

    //植木鉢の巨大化処理(10/7 18:21)
    private void UekibachiGiantMode()
    {
        Uekibachi.transform.localScale = new Vector3(Uekibachi.transform.localScale.x * UekibachiGiantSize, Uekibachi.transform.localScale.y * UekibachiGiantSize, Uekibachi.transform.localScale.z);
        /*
        Vector3 localScale = Uekibachi.transform.localScale;
        localScale.x *= UekibachiGiantSize;
        localScale.y *= UekibachiGiantSize;
        localScale.z *= UekibachiGiantSize;
        Uekibachi.transform.localScale = localScale;
        */

        //マテリアル変化処理(10/7 18:30)
    }

    //タイムオーバー時の操作不能処理(10/7 17:43)
    public void TimeOverEnd()
    {
        PlayableNum = 1;
    }

    public void GameStart()
    {
        PlayableNum = 0;
    }

	// 当たり判定
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "obstacle")
		{ // プレイヤーの場合

			// デバッグ表示
			Debug.Log("障害物Hit");

			// 障害物に当たった時のミント数、体力減少処理
			HitDamage();

			// デバッグ表示
			Debug.Log(MintNum);
		}
	}
}
