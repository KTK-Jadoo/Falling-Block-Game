using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
    static float secondsToMaxDiff = 20;
    public static float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDiff);
    }
}
