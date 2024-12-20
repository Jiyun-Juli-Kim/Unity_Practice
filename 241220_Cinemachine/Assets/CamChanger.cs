using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;


public class CamChanger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] cameras;
    [SerializeField] private Button[] buttons;

    private void OnEnable()
    {
        buttons[0].onClick.AddListener(FirstCamOn);
        buttons[1].onClick.AddListener(SecondCamOn);
    }

    private void FirstCamOn()
    {
        cameras[0].Priority = 11;
    }

    private void SecondCamOn()
    {
        cameras[0].Priority = 9;
    }

    private void OnDisable()
    {
        buttons[0].onClick.RemoveListener(FirstCamOn);
        buttons[0].onClick.RemoveListener(SecondCamOn);
    }
}
