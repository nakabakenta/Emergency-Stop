using UnityEngine;

public class TrainFormation : MonoBehaviour
{
    public int formationCar;         //両数
    protected float moveSpeed;       //速度
    protected GameObject[] formation;//編成

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        formation = new GameObject[formationCar];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
