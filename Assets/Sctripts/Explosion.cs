using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour, IExplosion
{
    [SerializeField] private Rigidbody _rigidbody;

    private Vector3 _currentDirection;

    public void Enter() 
    {
        
    }

    public void Exit()
    {
        
    }

    public void Initiate(Vector3 direction)
    {
        _currentDirection = direction;   
    }

    private void FixedUpdate()
    {
        if (_currentDirection != Vector3.zero)
        {
            _rigidbody.AddForce(_currentDirection, ForceMode.Impulse);
            _currentDirection = Vector3.zero;
        }
        
    }
}
