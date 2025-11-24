using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeMouse : MonoBehaviour
{
    private ITake _takeObject;

    private void Update()
    {
        TakeItem();
    }

    private void TakeItem()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_takeObject == null)
            {
                Ray ray = GetScreenPointToRay();
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    ITake takeObject = hit.collider.GetComponent<ITake>();
                    if (takeObject != null)
                    {
                        _takeObject = takeObject;
                        _takeObject.Enter();
                    }
                }
            }
        }

        if (Input.GetMouseButton(0) && _takeObject != null)
        {
            Ray ray = GetScreenPointToRay(); 
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _takeObject.UpdateMove(hit.point);
            }   
        }
        else if (_takeObject != null)
        {
            _takeObject.Exit();
            _takeObject = null;
        }
    }

    private Ray GetScreenPointToRay() => Camera.main.ScreenPointToRay(Input.mousePosition);
}
