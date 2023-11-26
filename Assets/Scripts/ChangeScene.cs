using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void pindah(int number)
    {
        StartCoroutine(MoveScene(number));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator MoveScene(int number)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(number);
    }
}
