using System.Collections.Generic;
using UnityEngine;

public class Function : MonoBehaviour
{
    //Vector3‚Ì’l‚ğİ’è‚·‚é
    public static Vector3 SetVector3(float value)
    {
        Vector3 vector = new Vector3(value, value, value);
        return vector;
    }

    //F‚ğİ’è‚·‚é(Color)
    public static Color SetColor(Color color)
    {
        return new Color(color.r / 255f, color.g / 255f, color.b / 255f, color.a / 255f);
    }

    //‘¬“x‚ğİ’è‚·‚é(km/h)
    public static float SetSpeed(float speed)
    {
        return speed * 3.6f;
    }
}