using System;
using UnityEngine;

public class Health
{
    private int _maxValue;
    private int _minValue;
    private int _currentValue;

    public int CurrentValue => _currentValue;

    public Health(int maxValue, int currentValue, int minValue = 0)
    {
        _maxValue = maxValue;
        _currentValue = currentValue;
        _minValue = minValue;
    }

    public bool TryDecreaseValue(int value)
    {
        if (value <= 0)
        {
            return false;
        }

        _currentValue -= value;

        Mathf.Clamp(_currentValue, _minValue, _maxValue);

        return true;
    }

    public void IncreaseValue(int value)
    {
        _currentValue += value;

        if (value > _maxValue)
        {
            value = _maxValue;

            throw new ArgumentException($"Parameter cannot be greater {_maxValue}", nameof(value));
        }
    }

    public void SetValueToMax()
    {
        _currentValue = _maxValue;
    }
}
