using UnityEngine;

public class Function : MonoBehaviour
{
    //Vector3の値を全てリセットする
    public static Vector3 ResetVector3(float value)
    {
        Vector3 vector = new Vector3(value, value, value);
        return vector;
    }
}