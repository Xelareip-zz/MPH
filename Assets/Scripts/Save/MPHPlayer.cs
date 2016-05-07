using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class MPHPlayer
{
    private static MPHPlayer _instance;
    public static MPHPlayer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MPHPlayer();
            }
            return _instance;
        }
    }

    public int _dollars = 0;
    public List<string> _levelsDone = new List<string>();
    public List<string> _levelsUnlocked = new List<string>();

    private MPHPlayer()
    {
        Load();
        UnlockLevel("1");
    }

    private void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Save.dat") == false)
        {
            return;
        }
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/Save.dat");
        string saveString = reader.ReadToEnd();
        reader.Close();
        saveString = saveString.Replace("\r", "");
        string[] saveLines = saveString.Split('\n');

        foreach (string line in saveLines)
        {
            string[] lineSplit = line.Split(':');
            switch(lineSplit[0])
            {
                case "dollars":
                    _dollars = int.Parse(lineSplit[1]);
                    break;
                case "levelDone":
                    _levelsDone.Add(lineSplit[1]);
                    break;
                case "levelUnlocked":
                    _levelsUnlocked.Add(lineSplit[1]);
                    break;
                default:
                    break;
            }
        }
        
    }
    
    public void Save()
    {
        string saveString = "";

        saveString += "dollars:" + _dollars + "\n";

        foreach (string levelDone in _levelsDone)
        {
            saveString += "levelDone:" + levelDone + "\n";
        }

        foreach (string levelUnlocked in _levelsUnlocked)
        {
            saveString += "levelUnlocked:" + levelUnlocked + "\n";
        }

        Directory.GetParent(Application.persistentDataPath).Create();
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/Save.dat");
        writer.Write(saveString);
        writer.Close();
    }

    public void ValidateLevel(string levelId)
    {
        if (_levelsDone.Contains(levelId) == false)
        {
            _levelsDone.Add(levelId);
        }
        int parseResult;
        if (int.TryParse(levelId, out parseResult))
        {
            UnlockLevel((parseResult + 1).ToString());
        }
    }

    public void UnlockLevel(string levelId)
    {
        if (_levelsUnlocked.Contains(levelId) == false)
        {
            _levelsUnlocked.Add(levelId);
            Save();
        }
    }
}
