using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Player;

public class JsonSaver : IDataSaver
{
    private const string FileName = "SaveData";
    private const string SaveFileExtensions = ".json";

    private Data _playerData;

    public JsonSaver()
    {
        _playerData = (Data) Load();
        Debug.Log(_playerData.Health);
    }

    private string SavePath => Application.persistentDataPath;
    private string FullPath => Path.Combine(SavePath, $"{FileName}{SaveFileExtensions}");

    public void Save()
    {
        var json = JsonConvert.SerializeObject(_playerData);

        using (var fileStream = new StreamWriter(FullPath))
        {
            fileStream.Write(json);
        }
    }

    public object TryLoad()
    {
        if (DataAlreadyExist())
            return null;

        return JsonConvert.DeserializeObject<Data>(File.ReadAllText(FullPath));
    }

    public object Load()
    {
        if (TryLoad() == null)
        {
            _playerData = new Data();
        }

        return _playerData;
    }

    private bool DataAlreadyExist() => File.Exists(FullPath);
}

