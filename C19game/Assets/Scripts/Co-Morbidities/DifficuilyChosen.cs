using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficuilyChosen : MonoBehaviour
{
    public void normalChosen()
    {
        Difficulty.difficulty = 1;
        Difficulty.scoreMultiplier = 1.0f;
    }
    public void oldChosen()
    {
        Difficulty.difficulty = 3;
        Difficulty.scoreMultiplier = 2.0f;
    }
    public void diabeticChosen()
    {
        Difficulty.difficulty = 2;
        Difficulty.scoreMultiplier = 1.5f;
    }
}
