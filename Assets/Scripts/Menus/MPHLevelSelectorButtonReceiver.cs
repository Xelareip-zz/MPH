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
        MPHLevelSelectorButtonInitializer[] buttonsInitializers = FindObjectsOfType<MPHLevelSelectorButtonInitializer>();
        foreach (MPHLevelSelectorButtonInitializer initializer in buttonsInitializers)
        {
            Text buttonText = initializer.GetComponentInChildren<Text>();
            if (MPHPlayer.Instance._levelsUnlocked.Contains(buttonText.text) == false)
            {
                initializer.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void LoadLevel(string levelId)
    {
        string levelText = "Level" + levelId;
        SceneManager.LoadScene(levelText);
    }
}
