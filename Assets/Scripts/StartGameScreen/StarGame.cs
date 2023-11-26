using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public string sceneNameToLoad;

    public void LoadScene()
    {

        SceneManager.LoadScene(sceneNameToLoad);
    }
    public void QuitApplication(){
        Application.Quit();
    }
}

