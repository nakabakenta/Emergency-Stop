using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void LoadScene(string str)
    {
        SceneManager.LoadSceneAsync(str);
        GameBase.scene = str;
    }
}
