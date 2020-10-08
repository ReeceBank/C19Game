using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PHSceneLoaderMaintoGame : MonoBehaviour
{
    public void LoadProtoGame() //depreciated, use LoadOneForward
    {
        LoadOneForward();
    }
    public void LoadOneForward() //for going forward a single scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadOneBack() // for going back a single scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
