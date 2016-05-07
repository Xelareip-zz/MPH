using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MPHLevelSelectorButtonReceiver : MonoBehaviour
{
    private static MPHLevelSelectorButtonReceiver _instance;
    public static MPHLevelSelectorButtonReceiver Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MPHLevelSelectorButtonReceiver>();
            }
            return _instance;
        }
    }

    void Start()
    {
        _instance = this;
    }

    public void LoadLevel(string levelId)
    {
        string levelText = "Level" + levelId;
        SceneManager.LoadScene(levelText);
    }
}
