using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public SceneChanger scene { get; private set; }

    [SerializeField] private float _playerHp = 100;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        SetSingleton();
        scene = GetComponent<SceneChanger>();
    }

    private void SetSingleton()
    {
        if (instance != null)
        {
            Destroy(instance);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
