using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenGame : MonoBehaviour
{
    public void OpenGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
