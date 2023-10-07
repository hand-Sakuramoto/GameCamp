using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitileScene : MonoBehaviour
{

    public AudioClip sound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey){
           audioSource.PlayOneShot(sound);//SEを鳴らす
           Invoke("ChangeScene", 0.25f);//シーンをまたぐとSEが破棄され、途切れるため、少し待つ対処をとる。
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Result");//メインシーンに遷移させる
    }

}
