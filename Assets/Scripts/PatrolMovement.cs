using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatrolMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _startMoveRight;
    [SerializeField] private LayerMask _wallLayer;
    [SerializeField] private Transform _linecastStart;

    private Vector3 _direction;
    private Vector3 _linecastDownOffset = new Vector2(0, -0.5f);
    private Vector3 _linecastForwardOffset = new Vector2(0.5f, 0);

    private void Start()
    {
        _direction = _startMoveRight ? Vector2.right : Vector2.left;

        if (!_startMoveRight)
            FlipScale();
    }

    private void Update()
    {
        if (!CanMoveForward())
        {
            FlipScale();
            _direction *= -1;
        }

        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private bool CanMoveForward()
    {
        var linecastEndForwardPosition = _linecastStart.position + _linecastForwardOffset;
        var linecastEndDownPosition = _linecastStart.position + _linecastDownOffset;

        RaycastHit2D forwardHit = Physics2D.Linecast(_linecastStart.position, linecastEndForwardPosition, _wallLayer);
        RaycastHit2D downHit = Physics2D.Linecast(_linecastStart.position, linecastEndDownPosition, _wallLayer);

        return !(forwardHit || !downHit);
    }

    private void FlipScale()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

}

