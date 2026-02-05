using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void LoadScene(string str)
    {
        GameBase.scene = str;
        SceneManager.LoadSceneAsync(str);
    }
}
