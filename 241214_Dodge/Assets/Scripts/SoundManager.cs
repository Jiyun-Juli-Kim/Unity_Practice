using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public SoundManager Instance { get; private set; }

    private void SetManager()
    {
        if (Instance == null)
        {
            Instance = ga;
        }
    }


}
