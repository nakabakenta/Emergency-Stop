using System.Threading;
using UnityEngine;

public class StageBase : MonoBehaviour
{
    public int score;
    protected float baseSpeed;
    protected int stageLevel;
    protected string stageName;
    protected string gamePhase;//ゲームフェイズ

    public float limit; //限界値
    private float timer;//タイマー

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
