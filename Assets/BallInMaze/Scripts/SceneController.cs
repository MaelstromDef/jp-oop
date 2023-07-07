using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    private void Start()
    {
        // Enforce Singleton
        if (Instance != null) Destroy(gameObject);

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void PlayGame()
    {
        SceneManager.LoadScene("MyGame");
    }

    public static void ToEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }

    public static void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
