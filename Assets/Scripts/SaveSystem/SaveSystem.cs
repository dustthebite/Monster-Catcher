using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using SimpleJSON;
using Zenject;
public class SaveSystem : MonoBehaviour
{
    [Inject] Player controlls;
    string playerDataSavePath;
    string itemDataSavePath;
    string unitDataSavePath;
    public event Action OnSave; 
    public event Action OnLoad;

    void Start()
    {
        controlls.System.Save.performed += ctx => ReadSaveInput();
        controlls.System.Load.performed += ctx => ReadLoadInput();
    }
    void OnDestroy()
    {
        controlls.System.Save.performed -= ctx => ReadSaveInput();
        controlls.System.Load.performed -= ctx => ReadLoadInput();
    }
    void ReadSaveInput()
    {
	    OnSave?.Invoke();
    }
    void ReadLoadInput()
    {
        OnLoad?.Invoke();
    }

    public void Save(string directoryName, string fileName, ISaveData saveData) 
    {
        JSONNode json = new JSONObject();
        json = JSON.Parse(JsonUtility.ToJson(saveData));
        string filePath = Application.persistentDataPath + "/" + directoryName + "/" + fileName + ".json";
        if(File.Exists(filePath))
        {
            File.WriteAllText(filePath, json.ToString());
        }
        else
        {
            Debug.LogError("Couldnt save");
        }
    }

    public T Load<T>(string directoryName, string fileName) where T : ISaveData
    {
        string filePath = Application.persistentDataPath + "/" + directoryName + "/" + fileName + ".json";
        if (File.Exists(filePath))
        {
            return JsonUtility.FromJson<T>(File.ReadAllText(filePath));
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
            return default(T);
        }
    }
}