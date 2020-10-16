using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficuilyChosen : MonoBehaviour
{
    /*
     * sets diffculty and scoreMultiplier for normal selection
     */
    public void normalChosen()
    {
        Difficulty.difficulty = 1;
        Difficulty.scoreMultiplier = 1.0f;
    }

    /*
     * sets diffculty and scoreMultiplier for elderly person selection
     */
    public void oldChosen()
    {
        Difficulty.difficulty = 3;
        Difficulty.scoreMultiplier = 2.0f;
    }

    /*
     * sets diffculty and scoreMultiplier for diabetic person selection
     */
    public void diabeticChosen()
    {
        Difficulty.difficulty = 2;
        Difficulty.scoreMultiplier = 1.5f;
    }
}
