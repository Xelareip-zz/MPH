using UnityEngine;
using System.Collections.Generic;

public class MPHGoToChapter : MonoBehaviour
{
    public List<GameObject> _chapterObjects;

    public void GoToChapter(int chapter)
    {
        if (chapter > 0 && chapter <= _chapterObjects.Count)
        {
            for (int i = 0; i < _chapterObjects.Count; ++i)
            {
                if (i != chapter - 1)
                {
                    _chapterObjects[i].SetActive(false);
                }
                else
                {
                    _chapterObjects[i].SetActive(true);
                }
            }
        }
    }
}
