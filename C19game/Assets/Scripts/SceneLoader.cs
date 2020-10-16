using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
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
    public void LoadLeader()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadInfoScene()
    {
        SceneManager.LoadScene("MiniGameInfoScene");
    }

    public void LoadMiniGame()
    {
        SceneManager.LoadScene("MiniGame");
    }
    public void LoadEndGame()
    {
        SceneManager.LoadScene("EndGame");
    }

    public void LoadWin()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void LoadShopLevel()
    {
        SceneManager.LoadScene("ShoppingLevel");
    }

    public void LoadQuarantineLevel()
    {
        SceneManager.LoadScene("QuarantineLevel");
    }
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void LoadMorbid()
    {
        SceneManager.LoadScene("Morbidities");
    }

    public void LoadScore()
    {
        SceneManager.LoadScene("AddScore_Scene");
    }
    public void LoadSchoolLevel()
    {
        SceneManager.LoadScene("SchoolLevel");
    }

}
