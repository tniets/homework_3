using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _health;

    public event Action<float> OnHealthPercentageChanged = delegate {};

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void ModifyHealth(float amount)
    {
        _health += amount;

        if (_health <= 0)
            Destroy(gameObject);

        if (_health > _maxHealth)
            _health = _maxHealth;

        var healthPercentage = _health / _maxHealth;

        OnHealthPercentageChanged(healthPercentage);
    }
}
