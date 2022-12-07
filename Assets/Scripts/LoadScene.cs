using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] string sceneName;
    public void changeScene(string name)
    {
        if (name != null)
        {
            SceneManager.LoadScene(name);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            changeScene(sceneName);
        }
    }
}
