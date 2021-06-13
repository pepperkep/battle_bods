using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public List<string> sceneNames;
    public int currentSceneIndex = 0;

    public void LoadNextScene()
    {
        currentSceneIndex += 1;
        SceneManager.LoadScene(sceneNames[currentSceneIndex]);
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static void FindAndLoadNextScene()
    {
        SceneManagement currentSceneManagement = GameObject.Find("SceneManager").GetComponent<SceneManagement>();
        currentSceneManagement.LoadNextScene();
    }
}
