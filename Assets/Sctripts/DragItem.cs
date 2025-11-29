using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItem 
{
    private IDraggable _takeObject;

    public void ItemUp(Ray ray)
    {
        if (_takeObject == null)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                IDraggable takeObject = hit.collider.GetComponent<IDraggable>();
                if (takeObject != null)
                {
                    _takeObject = takeObject;
                    _takeObject.OnGrab();
                }
            }
        }
    }

    public void Drag(Ray ray)
    {
        if (_takeObject != null)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _takeObject.UpdateMove(hit.point);
            }
        }
    }

    public void Release()
    {
        if (_takeObject != null)
        {
            _takeObject.OnRealese();
            _takeObject = null;
        }     
    }
}
