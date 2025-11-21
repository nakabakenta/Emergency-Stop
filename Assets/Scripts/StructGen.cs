using System.Collections.Generic;
using UnityEngine;

public class StructGen : MonoBehaviour
{
    //ストラクチャー構造体
    [System.Serializable]
    public struct Struct
    {
        [Header("レールの生成位置(直線)")]
        public Vector3 p0;
        public Vector3 p3;

        [Header("レールの生成位置(曲線)")]
        public Vector3 p1;
        public Vector3 p2;

        [Header("配置するオブジェクト")]
        public GameObject[] objPrefab;

        [Header("配置間隔（メートル単位）")]
        public float spacing;

        [Header("精度（大きいほど正確だが重くなる）")]
        public int sampleResolution;
    }

    public Struct[] structGen;

    void Start()
    {
        for (int index = 0; index < structGen.Length; index++)
        {
            PlaceObjectsAlongBezier(index);
        }
    }

    void PlaceObjectsAlongBezier(int num)
    {
        // 曲線全体をサンプリングして距離テーブルを作る
        List<float> distances = new List<float>();
        List<Vector3> points = new List<Vector3>();

        float totalLength = 0f;
        Vector3 prevPoint = GetCubicBezierPoint(0, structGen[num].p0, structGen[num].p1, structGen[num].p2, structGen[num].p3);

        points.Add(prevPoint);
        distances.Add(0);

        for (int i = 1; i <= structGen[num].sampleResolution; i++)
        {
            float t = i / (float)structGen[num].sampleResolution;
            Vector3 point = GetCubicBezierPoint(t, structGen[num].p0, structGen[num].p1, structGen[num].p2, structGen[num].p3);
            totalLength += Vector3.Distance(prevPoint, point);
            points.Add(point);
            distances.Add(totalLength);
            prevPoint = point;
        }

        // 間隔ごとにオブジェクトを配置
        for (float dist = 0; dist <= totalLength; dist += structGen[num].spacing)
        {
            float t = GetTAtDistance(distances, dist);
            Vector3 position = GetCubicBezierPoint(t, structGen[num].p0, structGen[num].p1, structGen[num].p2, structGen[num].p3);

            for (int index = 0; index < structGen[num].objPrefab.Length; index++)
            {
                GameObject obj = Instantiate(structGen[num].objPrefab[index], position, Quaternion.identity, transform);
                // 進行方向を向かせる（次の点を参照）
                float nextT = Mathf.Min(t + 0.01f, 1f);
                Vector3 nextPos = GetCubicBezierPoint(nextT, structGen[num].p0, structGen[num].p1, structGen[num].p2, structGen[num].p3);
                obj.transform.LookAt(nextPos);
            }
        }
    }

    // t値に対する点を取得
    Vector3 GetCubicBezierPoint(float t, Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        float u = 1 - t;
        return u * u * u * a +
               3 * u * u * t * b +
               3 * u * t * t * c +
               t * t * t * d;
    }

    // 指定した距離に最も近いt値を求める
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
