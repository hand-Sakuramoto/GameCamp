using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameManager : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
