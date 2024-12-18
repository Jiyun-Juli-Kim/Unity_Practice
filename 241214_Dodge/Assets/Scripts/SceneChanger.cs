using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Load(int SceneNum)
    {
        SceneManager.LoadScene(SceneNum);
    }
    
    public void Load(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
