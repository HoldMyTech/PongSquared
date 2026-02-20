using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // System.Collections is not strictly necessary for this specific script

public class SceneChanger : MonoBehaviour
{
    public string nextSceneName;
    
    public void LoadNextScene()
    {
     
        SceneManager.LoadScene(nextSceneName);
    }
}