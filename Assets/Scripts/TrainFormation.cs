using UnityEngine;

public class TrainFormation : MonoBehaviour
{
    public int formationCar;         //����
    protected float moveSpeed;       //���x
    protected GameObject[] formation;//�Ґ�

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
