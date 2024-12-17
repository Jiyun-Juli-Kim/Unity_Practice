using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public SceneChanger scene { get; private set; }

    [SerializeField] public float PlayerHp = 100;

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
        if (Instance != null)
        {
            Destroy(Instance);
        }

        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
