using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    [Header("プレイヤー移動速度")] public float PlayerSpeed;
    [Header("持っているミントの数")] public float MintNum = 0;
    [Header("プレイヤーの体力")] public int PlayerHP;

    private Rigidbody rb; //RigidBody宣言　(10/7 12:22)


    private int PlayableNum = 0; //変数によるプレイヤー操作可能タイミング制限（0が操作可能、1が準備、ゲーム終了時など操作不能時）




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
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

            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                rb.velocity = Vector3.zero;
            }
            //移動ここまで
        }
    }
}
