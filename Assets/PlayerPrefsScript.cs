using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPrefsScript : MonoBehaviour
{
    public TMP_InputField inputFd;

    public void SaveData()
    {
        PlayerPrefs.SetString("Input", inputFd.text);
    }

    public void LoadData()
    {
        inputFd.text = PlayerPrefs.GetString("Input");
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("Input");
    }
}
