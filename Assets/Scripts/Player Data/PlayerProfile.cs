using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfile
{
    public string profileName;

    public PlayerProfile(string profileName)
    {
        this.profileName = profileName;
    }
}