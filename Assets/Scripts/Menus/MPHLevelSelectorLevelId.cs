using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MPHLevelSelectorLevelId : MonoBehaviour
{
    public Text _displayText;

	// Use this for initialization
	void Start ()
    {
        string levelId = SceneManager.GetActiveScene().name;
        _displayText.text = "Level " + levelId.Replace("Level", "");
	}
}
