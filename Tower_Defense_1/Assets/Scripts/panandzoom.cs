using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class panandzoom : MonoBehaviour
{
    private CinemachineInputProvider _inputProvider;
    private CinemachineVirtualCamera _cinemachineVirtual;
    private Transform cameraTransform;

    private float panSpeed = 2f;
    private float zoomSpeed = 3f;
    private float zoomInMax = 40f;
    private float zoomOutMax = 90f;

    private void Update()
    {
        float x = _inputProvider.GetAxisValue(0);
        float y = _inputProvider.GetAxisValue(1);
        float z = _inputProvider.GetAxisValue(2);
        if (x != 0 || y != 0)
        {
            PanScreen(x, y);
        }

        if (z != 0)
        {
            ZoomScreen(z);
        }
    }

    public void ZoomScreen(float increment)
    {
        float fov = _cinemachineVirtual.m_Lens.FieldOfView;
        float target = Mathf.Clamp(fov, zoomInMax, zoomOutMax);
        _cinemachineVirtual.m_Lens.FieldOfView = Mathf.Lerp(fov, target, zoomSpeed * Time.deltaTime);
    }
    private void Awake()
    {
        _inputProvider = GetComponent<CinemachineInputProvider>();
        _cinemachineVirtual = GetComponent<CinemachineVirtualCamera>();
        cameraTransform = _cinemachineVirtual.VirtualCameraGameObject.transform;
    }

    public Vector2 PanDirection(float x, float y)
    {
        Vector2 direction = Vector2.zero;
        if (y >= Screen.height * 0.95)
        {
            direction.y += 1;
        }
        else if (y <= Screen.height * 0.05)
        {
            direction.y -= 1;
        }
        else if (x >= Screen.width * 0.95)
        {
            direction.x += 1;
        }
        else if (x <= Screen.width * 0.05)
        {
            direction.x -= 1;
        }

        return direction;
    }
    public void PanScreen(float x, float y)
    {
        Vector2 direction = PanDirection(x, y);
        cameraTransform.Translate(direction * panSpeed * Time.deltaTime, Space.World);
    }
}
