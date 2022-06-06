using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSystem : MonoBehaviour
{
    public static PersistentSystem Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        Instance = null;
        Destroy(this.gameObject);
    }
}
