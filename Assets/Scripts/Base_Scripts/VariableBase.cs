using System;
using System.Numerics;
using UnityEngine;

/// <summary>
/// floatŒ^(‘OŒã)
/// </summary>
[Serializable]
public struct FloatFB2
{
    public float front;
    public float back;

    public FloatFB2(float front, float back)
    {
        this.front = front;
        this.back = back;
    }

    public static FloatFB2 operator +(FloatFB2 a, FloatFB2 b)
        => new FloatFB2(a.front + b.front, a.back + b.back);

    public static FloatFB2 operator -(FloatFB2 a, FloatFB2 b)
        => new FloatFB2(a.front - b.front, a.back - b.back);

    public static FloatFB2 operator *(FloatFB2 a, float d)
        => new FloatFB2(a.front * d, a.back * d);

    public static FloatFB2 operator /(FloatFB2 a, float d)
        => new FloatFB2(a.front / d, a.back / d);

    public float magnitude => Mathf.Sqrt(front * front + back * back);
    public FloatFB2 normalized => this / magnitude;

    public override string ToString() => $"({front:F2}, {back:F2})";
}

/// <summary>
/// boolŒ^(‘OŒã)
/// </summary>
[Serializable]
public struct BoolFB2
{
    public bool front;
    public bool back;

    public BoolFB2(bool front, bool back)
    {
        this.front = front;
        this.back = back;
    }

    public bool this[int index]
    {
        get
        {
            return index switch
            {
                0 => front,
                1 => back,
                _ => throw new IndexOutOfRangeException("Bool2 index must be 0 or 1"),
            };
        }
        set
        {
            switch (index)
            {
                case 0: front = value; break;
                case 1: back = value; break;
                default: throw new IndexOutOfRangeException("Bool2 index must be 0 or 1");
            }
        }
    }

    public override string ToString() => $"({front}, {back})";
}