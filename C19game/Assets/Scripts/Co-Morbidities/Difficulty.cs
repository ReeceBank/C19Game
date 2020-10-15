using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
    //for logic. old has a diff of 2 which will change and effect cards. Normal is baseline.
    public static int difficulty = 1;
    public static float scoreMultiplier = 1.0f;

    //to keep track of the last level selected to play for when going back.
    public static string lastLevel = "";

    //to keep track of the next level to go too after choosing morbidity
    public static string nextLevel = "";
}
