using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePackage
{
    public string playerName;
    public int levelIndex;
    public float time;

    public SavePackage(string playerName, int levelIndex, float time)
    {
        this.playerName = playerName;
        this.levelIndex = levelIndex;
        this.time = time;
    }
}
