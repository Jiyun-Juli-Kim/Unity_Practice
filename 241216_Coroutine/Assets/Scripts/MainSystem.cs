using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSystem : MonoBehaviour
{
    public static MainSystem Instance { get; private set; }


    private 
    
    
    
    
    
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
