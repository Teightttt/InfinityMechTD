using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDirection : MonoBehaviour
{
    void Update()
    {
        // ��ȡ�������
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            // ��Ѫ����Z��ʼ�ճ��������
            transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,mainCamera.transform.rotation * Vector3.up);
        }
    }
}
