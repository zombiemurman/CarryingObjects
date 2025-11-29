using Cinemachine;
using System.Collections.Generic;

public class CameraSwitcher
{
    private List<CinemachineVirtualCamera> _cameras;
    private Queue<CinemachineVirtualCamera> _camerasQueue;

    public CameraSwitcher(List<CinemachineVirtualCamera> cameras)
    {
        _cameras = cameras;
        _camerasQueue = new Queue<CinemachineVirtualCamera>(_cameras);
        SwitchNextCamera();
    }

    public void SwitchNextCamera()
    {
        CinemachineVirtualCamera nextCamera = _camerasQueue.Dequeue();

        foreach(var camera in _cameras)
            camera.gameObject.SetActive(false);

        nextCamera.gameObject.SetActive(true);

        _camerasQueue.Enqueue(nextCamera);
    }
}
