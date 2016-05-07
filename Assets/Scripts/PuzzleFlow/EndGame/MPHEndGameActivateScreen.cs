using UnityEngine;
using System.Collections;

public class MPHEndGameActivateScreen : MPHEndGame
{
    public GameObject _target;

    public override void DoAction()
    {
        _target.SetActive(true);
    }
}
