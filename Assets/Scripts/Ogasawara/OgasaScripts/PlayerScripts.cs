using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    [Header("プレイヤー移動速度")] public float PlayerSpeed;
    [Header("ミントの数")] public float MintNum = 0;
    [Header("プレイヤーの体力")] public int PlayerHP;

    private Rigidbody rb; //RigidBody宣言　(10/7 12:22)







    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
