using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    
    public string sceneNameToLoad;

    public void LoadScene()
    {
        
        SceneManager.LoadScene(sceneNameToLoad);
    }
}

