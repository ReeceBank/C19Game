using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /*
     * Loads the scene that is ahead of current scene
     */
    public void LoadProtoGame() //depreciated, use LoadOneForward
    {
        LoadOneForward();
    }

    /*
     * Loads the scene that is ahead of current scene
     */
    public void LoadOneForward() //for going forward a single scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*
     * Loads the scene that is behind the current scene
     */
    public void LoadOneBack() // for going back a single scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    /*
     * Loads the leaderboards scene
     */
    public void LoadLeader()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    /*
     * Loads the main menu scene
     */
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /*
     * Loads the minigame info scene
     */
    public void LoadInfoScene()
    {
        SceneManager.LoadScene("MiniGameInfoScene");
    }

    /*
     * Loads the minigame scene
     */
    public void LoadMiniGame()
    {
        SceneManager.LoadScene("MiniGame");
    }

    /*
     * Loads lose game scene
     */
    public void LoadEndGame()
    {
        SceneManager.LoadScene("EndGame");
    }

    /*
     * Loads the win game scene
     */
    public void LoadWin()
    {
        SceneManager.LoadScene("WinScene");
    }

    /*
     * Loads the shopping level scene
     */
    public void LoadShopLevel()
    {
        SceneManager.LoadScene("ShoppingLevel");
    }

    /*
     * Loads the quarantine level scene
     */
    public void LoadQuarantineLevel()
    {
        SceneManager.LoadScene("QuarantineLevel");
    }

    /*
     * Loads the level select scene
     */
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    /*
     * loads the difficulty(co-morbidity select) scene
     */
    public void LoadMorbid()
    {
        SceneManager.LoadScene("Morbidities");
    }

    /*
     * Loads the add score scene
     */
    public void LoadScore()
    {
        SceneManager.LoadScene("AddScore_Scene");
    }

    /*
     * Loads the school level scene
     */
    public void LoadSchoolLevel()
    {
        SceneManager.LoadScene("SchoolLevel");
    }

}
