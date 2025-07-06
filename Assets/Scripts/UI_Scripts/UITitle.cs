using UnityEngine;

public class UITitle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneLoader.LoadScene(SceneName.GameModeSelect.ToString());
        }
    }
}
