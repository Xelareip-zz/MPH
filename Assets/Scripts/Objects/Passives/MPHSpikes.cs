using UnityEngine;
using System.Collections;

public class MPHSpikes : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject == MPHBall.Instance.gameObject)
        {
            MPHPuzzleManager.Instance.Restart();
        }
    }
}
