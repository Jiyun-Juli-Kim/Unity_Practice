using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HpBarController : MonoBehaviour
{
    Slider hpBar;
    [SerializeField] private PlayerController _player;

    private void Awake()
    {
        hpBar = GetComponent<Slider>();
    }

    private void Start()
    {
        hpBar.maxValue = 100f;
        hpBar.value = _player._playerHp;
    }

    private void Update()
    {
        hpBar.value = _player._playerHp;
    }

}
