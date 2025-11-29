using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodable : MonoBehaviour, IExplodable
{
    [SerializeField] private Rigidbody _rigidbody;

    private Vector3 _currentDirection;

    public void Explode(Vector3 direction)
    {
        _currentDirection = direction;   
    }

    private void Update()
    {
        if (_currentDirection != Vector3.zero)
        {
            _rigidbody.AddForce(_currentDirection, ForceMode.Impulse);
            _currentDirection = Vector3.zero;
        }
    }
}
