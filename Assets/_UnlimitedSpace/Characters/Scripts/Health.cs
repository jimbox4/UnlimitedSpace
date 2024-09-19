using System;

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

    public void DecreaseValue(int value)
    {
        _currentValue -= value;

        if (value < _minValue)
        {
            value = _minValue;

            throw new ArgumentException($"Parameter cannot be bellow {_minValue}", nameof(value));
        }
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
}
