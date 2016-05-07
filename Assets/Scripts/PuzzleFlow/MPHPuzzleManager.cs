using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MPHPuzzleManager : MonoBehaviour
{

    private static MPHPuzzleManager _instance;
    public static MPHPuzzleManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MPHPuzzleManager>();
            }
            return _instance;
        }
    }


    public MPHEndGame _winGameObject;
    public MPHEndGame _looseGameObject;
    public Dictionary<MPHPuzzleObjective, bool> _objectivesStatus = new Dictionary<MPHPuzzleObjective, bool>();

    public event Action restartEvent;


    void Start()
    {
        MPHPuzzleObjective[] objectives = FindObjectsOfType<MPHPuzzleObjective>();

        foreach (MPHPuzzleObjective objective in objectives)
        {
            RegisterObjective(objective);
        }
    }

    public void RegisterObjective(MPHPuzzleObjective newObjective)
    {
        if (_objectivesStatus.ContainsKey(newObjective) == false)
        {
            _objectivesStatus.Add(newObjective, false);
        }
    }

    public void ObjectiveFilled(MPHPuzzleObjective objectiveFilled)
    {
        _objectivesStatus[objectiveFilled] = true;
        foreach (KeyValuePair<MPHPuzzleObjective, bool> kvp in _objectivesStatus)
        {
            if (kvp.Value == false)
            {
                return;
            }
        }
        WinGame();
    }

    public void Restart()
    {
        List<MPHPuzzleObjective> keys = new List<MPHPuzzleObjective>();
        keys.AddRange(_objectivesStatus.Keys);

        foreach (MPHPuzzleObjective objective in keys)
        {
            _objectivesStatus[objective] = false;
        }

        if (restartEvent != null)
        {
            restartEvent();
        }
    }

    public void WinGame()
    {
        MPHPlayer.Instance.ValidateLevel(SceneManager.GetActiveScene().name.Replace("Level", ""));
        _winGameObject.DoAction();
    }

    public void LooseGame()
    {
        _looseGameObject.DoAction();
    }
}
