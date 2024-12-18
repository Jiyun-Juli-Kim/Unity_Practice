using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeCounter : MonoBehaviour
{
    private float _initTime;

    Slider timeBar;
    
    // 이거 awake에서 하면 실행이 안되던뎅..
    private void Start()
    {
        timeBar = GetComponent<Slider>();
        timeBar.value = 1f;
        
        _initTime = GameManager.Instance.playTime;
        Debug.Log(_initTime);
    }

    private void Update()
    {
        GameManager.Instance.playTime -= Time.deltaTime;
        timeBar.value = GameManager.Instance.playTime/_initTime;
    }
}
