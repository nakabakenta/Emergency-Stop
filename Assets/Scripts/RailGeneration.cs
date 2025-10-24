using System.Collections.Generic;
using UnityEngine;

public class RailGeneration : MonoBehaviour
{
    [Header("���[���̐����ʒu(����)")]
    public Vector3 p0;
    public Vector3 p3;

    [Header("���[���̐����ʒu(�Ȑ�)")]
    public Vector3 p1;
    public Vector3 p2;

    [Header("�z�u����I�u�W�F�N�g")]
    public GameObject prefab;

    [Header("�z�u�Ԋu�i���[�g���P�ʁj")]
    public float spacing;

    [Header("���x�i�傫���قǐ��m�����d���Ȃ�j")]
    public int sampleResolution;

    void Start()
    {
        PlaceObjectsAlongBezier();
    }

    void PlaceObjectsAlongBezier()
    {
        // �Ȑ��S�̂��T���v�����O���ċ����e�[�u�������
        List<float> distances = new List<float>();
        List<Vector3> points = new List<Vector3>();

        float totalLength = 0f;
        Vector3 prevPoint = GetCubicBezierPoint(0, p0, p1, p2, p3);

        points.Add(prevPoint);
        distances.Add(0);

        for (int i = 1; i <= sampleResolution; i++)
        {
            float t = i / (float)sampleResolution;
            Vector3 point = GetCubicBezierPoint(t, p0, p1, p2, p3);
            totalLength += Vector3.Distance(prevPoint, point);
            points.Add(point);
            distances.Add(totalLength);
            prevPoint = point;
        }

        // �Ԋu���ƂɃI�u�W�F�N�g��z�u
        for (float dist = 0; dist <= totalLength; dist += spacing)
        {
            float t = GetTAtDistance(distances, dist);
            Vector3 position = GetCubicBezierPoint(t, p0, p1, p2, p3);
            GameObject obj = Instantiate(prefab, position, Quaternion.identity, transform);

            // �i�s��������������i���̓_���Q�Ɓj
            float nextT = Mathf.Min(t + 0.01f, 1f);
            Vector3 nextPos = GetCubicBezierPoint(nextT, p0, p1, p2, p3);
            obj.transform.LookAt(nextPos);
        }
    }

    // t�l�ɑ΂���_���擾
    Vector3 GetCubicBezierPoint(float t, Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        float u = 1 - t;
        return u * u * u * a +
               3 * u * u * t * b +
               3 * u * t * t * c +
               t * t * t * d;
    }

    // �w�肵�������ɍł��߂�t�l�����߂�
    float GetTAtDistance(List<float> distances, float targetDist)
    {
        for (int i = 1; i < distances.Count; i++)
        {
            if (distances[i] >= targetDist)
            {
                float prevDist = distances[i - 1];
                float nextDist = distances[i];
                float segmentLength = nextDist - prevDist;
                float t = (i - 1 + (targetDist - prevDist) / segmentLength) / (distances.Count - 1);
                return Mathf.Clamp01(t);
            }
        }
        return 1f;
    }
}
