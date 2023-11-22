using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData : MonoBehaviour
{
    public float PositionX;
    public float PositionY;
}

public static class GameEventSystem
{
    public static event Action<SaveData> OnSaveData;
    public static event Action<SaveData> OnLoadData;

    
    
    public static void SaveGame(SaveData data)
    {
        OnSaveGame?.Invoke(data);
    }
    
    public static void LoadGame(SaveData data)
    {
        OnLoadGame?.Invoke(data);
    }
}

public class BasicPlayerMovement : MonoBehaviour
{
    private void Awake ()
    {
        GameEventSystem.OnSaveData += SaveData;
        GameEventSystem.OnSaveData += LoadGame;
    }

    private void OnDestroy ()
    {
        GameEventSystem.OnSaveData -= SaveData;
        GameEventSystem.OnSaveData -= LoadGame;
    }

    private void SaveGame(SaveData data)
    {
        Vector3 position = transform.position;
        data.PositionX = position.x;
        data.PositionY = position.y;
    }

    private void LoadGame(SaveData data)
    {
        Vector2 position = new Vector2()
        {
            x = data.PositionX,
            y = data.PositionY
        };
        transform.position = position;
    }
    }

public static class SimpleSaveSystem
{
    public static void SaveXML() { ...}

    public static void LoadXML() { ...}

    public static void SaveBinary() { ...}

    public static void LoadBinary() { ...}
}

}




