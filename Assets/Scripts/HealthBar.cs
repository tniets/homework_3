using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _updateSpeedSeconds;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.OnHealthPercentageChanged += HandleHealthChanged;
    }

    private void OnDisable()
    {
        _health.OnHealthPercentageChanged -= HandleHealthChanged;
    }

    private void HandleHealthChanged(float value)
    {
        StartCoroutine(ChangeToPercentage(value));
    }

    private IEnumerator ChangeToPercentage(float percentage)
    {
        float preChangeValue = _slider.value;
        float elapsed = 0f;

        while (elapsed < _updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            _slider.value = Mathf.Lerp(preChangeValue, percentage, elapsed / _updateSpeedSeconds);
            yield return null;
        }

        _slider.value = percentage;
    }
}
