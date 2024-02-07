using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamManager : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;
    CinemachineFramingTransposer Transposer;
    public Camera Cam;
    public GameObject ssBar;
    public GameObject ssCam1;
    public GameObject ssCam2;
    public bool OverrideSplitscreen; //run the check splitscreen logic only if this is disabled. if this is disabled, you can set whether it's splitscreen or not manually.
    public bool inSplitscreen;

    void Awake()
    {
        Transposer = VirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!OverrideSplitscreen) inSplitscreen = Cam.fieldOfView == Transposer.m_MaximumFOV; //if the normal camera's FOV equals the max FOV from Cinemachine, it should enable the splitscreen cameras.
        ssCam1.SetActive(inSplitscreen);
        ssCam2.SetActive(inSplitscreen);
        ssBar.SetActive(inSplitscreen);
    }
}
