using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameEndManager : SingletonMonoBehaviour<GameEndManager>
{
    protected override bool IsDontDestroyOnLoad { get { return true; } }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}
