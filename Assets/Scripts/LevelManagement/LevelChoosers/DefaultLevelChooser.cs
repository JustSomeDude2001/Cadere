using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultLevelChooser : LevelChooser
{
    public int levelAmount;
    public override string chooseLevel()
    {
        int nextLevelNum = (int)(Random.value * levelAmount);
        
        //Preventing an unlikely, but possible event of
        //hitting a 1 on the RNG.
        if (nextLevelNum == levelAmount) {
            nextLevelNum--;
        }

        string nextLevelName = "Level";

        nextLevelName += nextLevelNum.ToString();

        return nextLevelName;
    }
}

