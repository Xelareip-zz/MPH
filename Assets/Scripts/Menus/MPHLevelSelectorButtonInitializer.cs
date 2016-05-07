using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MPHLevelSelectorButtonInitializer : MonoBehaviour
{
    void Start()
    {
        Button button = GetComponent<Button>();

        Text text = GetComponentInChildren<Text>();


        button.onClick.AddListener(delegate
        {
            MPHLevelSelectorButtonReceiver.Instance.LoadLevel(text.text);
        });
    }
}
