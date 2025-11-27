using UnityEngine;
using UnityEngine.UI;

public class UITitle : MonoBehaviour
{
    public Image blackout;
    private int nowStatus;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nowStatus == 0)
        {



        }
        else if (nowStatus == 1)
        {
            if (Input.anyKeyDown) SceneLoader.LoadScene(SceneName.Menu.ToString());
        }
    }
}
