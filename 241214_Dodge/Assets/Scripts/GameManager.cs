using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public SceneChanger sceneChanger { get; private set; }

    [field : SerializeField] public int Score { get; set; }

    [Range(5, 30)] 
    [SerializeField] public float playTime;


    void Awake()
    {
        Init();
    }

    public void Init()
    {
        SetSingleton();
        sceneChanger = GetComponent<SceneChanger>();
    }

    private void SetSingleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Load(int num)
    {
        Instance.sceneChanger.Load(num);
        // Debug.Log("씬 전환 수행");
    }

}
