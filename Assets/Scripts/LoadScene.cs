using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] string sceneName;
    public void changeScene(string name)
    {

        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;

    }
}
