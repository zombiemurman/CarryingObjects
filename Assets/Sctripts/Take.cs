using UnityEngine;

public class Take : MonoBehaviour, ITake
{
    [SerializeField] private Rigidbody _rigidbody;

    private Vector3 _currentTarget;
    
    private bool _isTake;

    private void FixedUpdate()
    {
        if (_isTake == false)
            return;

        _rigidbody.MovePosition(_currentTarget);
    }

    public void Enter()
    {
        _currentTarget = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        _rigidbody.useGravity = false;
        _isTake = true;
    }

    public void Exit()
    {
        _rigidbody.useGravity = true;
        _isTake = false;
    }

    public void UpdateMove(Vector3 target)
    {       
        _currentTarget = new Vector3(target.x, _currentTarget.y, target.z);    
    }
}
