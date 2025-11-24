using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> _cameras;

    private Queue<CinemachineVirtualCamera> _camerasQueue;

    private void Awake()
    {
        _camerasQueue = new Queue<CinemachineVirtualCamera>(_cameras);
        SwitchNextCamera();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
            SwitchNextCamera();
    }

    private void SwitchNextCamera()
    {
        CinemachineVirtualCamera nextCamera = _camerasQueue.Dequeue();

        foreach(var camera in _cameras)
            camera.gameObject.SetActive(false);

        nextCamera.gameObject.SetActive(true);

        _camerasQueue.Enqueue(nextCamera);
    }
}
