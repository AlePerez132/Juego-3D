using UnityEngine;

public class FuzzyVariable
{
    public float EvaluateLow(float x, float min, float max)
    {
        if (x <= min) return 1;
        if (x >= max) return 0;
        return (max - x) / (max - min);
    }

    public float EvaluateMedium(float x, float min, float peak, float max)
    {
        if (x <= min || x >= max) return 0;
        if (x == peak) return 1;
        if (x < peak) return (x - min) / (peak - min);
        return (max - x) / (max - peak);
    }

    public float EvaluateHigh(float x, float min, float max)
    {
        if (x <= min) return 0;
        if (x >= max) return 1;
        return (x - min) / (max - min);
    }
}
