using UnityEngine;

public class Function : MonoBehaviour
{
    //Vector3‚Ì’l‚ðÝ’è‚·‚é
    public static Vector3 SetVector3(float value)
    {
        Vector3 vector = new Vector3(value, value, value);
        return vector;
    }

    //F‚ðÝ’è‚·‚é(Color)
    public static Color SetColor(Color color)
    {
        return new Color(color.r / 255f, color.g / 255f, color.b / 255f, color.a / 255f);
    }

    //‘¬“x‚ðÝ’è‚·‚é(km/h)
    public static float SetSpeed(float speed)
    {
        return speed * 3.6f;
    }

    public static bool Timer(float timer, float time)
    {
        if (timer >= time) return true;

        return false;
    }

    public static GameObject FindAllChild(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
                return child.gameObject;

            GameObject result = FindAllChild(child, name);
            if (result != null)
                return result;
        }
        return null;
    }

    //
    public static Vector3 AlignRectTransform(RectTransform from, RectTransform target)
    {
        Vector3 worldPos = from.TransformPoint(from.rect.center);
        Vector3 localPos = target.parent.InverseTransformPoint(worldPos);

        return localPos;
    }
}