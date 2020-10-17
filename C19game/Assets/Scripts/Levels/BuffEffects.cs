using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuffEffects
{
    //this static script is to keep track of what unique cards are played so that
    //cards can logic about their effects better. 
    //eg: the facemask card will check if uncleanhands = true, then it will have no effect
    //further eg: when face mask is played its set to true, the when washdryiron is played it checks if facemask is true. 
    //if it is then its effects are stronger

    //bad card buff effects
    public static bool uncleanHands = false; 
    public static bool uncleanSurface = false;
    public static bool itchyface = false;

    //good card buff effects
    public static bool faceMask = false;
    public static bool washDryIron = false;
    public static bool cleanHands = false; //not specific to any 1 card
    public static bool coveredSneeze = false;

    //resets all bad effects, called when the player ENDS their turn
    public static void resetBad()
    {
        uncleanHands = false;
        uncleanSurface = false;
        itchyface = false;
    }
    //resets all good effects, called when the player STARTS their turn
    public static void resetGood()
    {
        faceMask = false;
        washDryIron = false;
        cleanHands = false; //not specific to any 1 card
        coveredSneeze = false;
    }
}
