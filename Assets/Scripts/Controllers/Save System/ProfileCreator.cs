using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileCreator : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Login loginScreen;

    public async void CreateProfile()
    {
        //if (!CheckIfAvilable(inputField.text))
        //    return;

        PlayerProfile profile = new PlayerProfile(inputField.text);
        SaveLoad.Save(profile, SaveLoad.playerProfileDataPath);

        loginScreen.LoadMainMenu();
    }

    private bool CheckIfAvilable(string profileName)
    {
        return true;
    }
}
