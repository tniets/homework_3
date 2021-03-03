using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var inputX = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * inputX * _speed * Time.deltaTime);

        var newLocalScaleX = inputX >= 0 ? 1 : -1f;

        if (newLocalScaleX != transform.localScale.x)
            transform.localScale = new Vector3(newLocalScaleX, transform.localScale.y, transform.localScale.z);

        _animator.SetBool("IsMoving", inputX != 0);
    }
}
