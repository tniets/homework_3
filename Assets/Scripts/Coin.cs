using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
    private Action _onPickUp;

    public void Init(Action onPickUp)
    {
        _onPickUp = onPickUp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            _onPickUp?.Invoke();
            Destroy(gameObject);
        }
            
    }
}
