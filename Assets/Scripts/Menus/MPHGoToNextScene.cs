using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MPHGoToNextScene : MonoBehaviour
{
    public void LoadNextLevel()
    {
        string currentLevel = SceneManager.GetActiveScene().name;
        currentLevel = currentLevel.Replace("Level", "");
        int intLevel = int.Parse(currentLevel);
        ++intLevel;
        SceneManager.LoadScene("Level" + intLevel);
    }
}
