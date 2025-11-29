using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> _cameras;

    private CameraSwitcher _cameraSwitcher;

    private DragItem _dragItem;

    private ExplosionHandler _explosionHandler;

    [SerializeField] private ParticleSystem _ExplosionEffect;

    private ExplosionView _explosionView;

    private void Awake()
    {
        _cameraSwitcher = new CameraSwitcher(_cameras);
        _dragItem = new DragItem();
        _explosionHandler = new ExplosionHandler(5, 10);
        _explosionView = new ExplosionView(_ExplosionEffect);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            _cameraSwitcher.SwitchNextCamera();
        }

        if(Input.GetMouseButtonDown(0))
        {
            _dragItem.ItemUp(GetScreenPointToRay());
        }

        if (Input.GetMouseButton(0))
        {
            _dragItem.Drag(GetScreenPointToRay());
        }

        if (Input.GetMouseButtonUp(0))
        {
            _dragItem.Release();
        }

        if(Input.GetMouseButtonDown(1))
        {
            _explosionHandler.ProcessExplosion(GetScreenPointToRay());
            _explosionView.ExplosionEffect(_explosionHandler.ExplosionPoint);
        }
    }

    private Ray GetScreenPointToRay() => Camera.main.ScreenPointToRay(Input.mousePosition);
}
