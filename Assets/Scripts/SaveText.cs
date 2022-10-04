using System;
using UnityEngine;
using UnityEngine.UI;

public class SaveText : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void OnDestroy()
    {
        MenuUIHandler.instance._data.name = text.text;
    }

    private void OnApplicationQuit()
    {
        MenuUIHandler.instance._data.name = text.text;
    }
}