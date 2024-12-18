using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDirection : MonoBehaviour
{
    void Update()
    {
        // 获取主摄像机
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            // 让血条的Z轴始终朝向摄像机
            transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,mainCamera.transform.rotation * Vector3.up);
        }
    }
}
