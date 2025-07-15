using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
        GameBase.nowScene = sceneName;
    }
}
