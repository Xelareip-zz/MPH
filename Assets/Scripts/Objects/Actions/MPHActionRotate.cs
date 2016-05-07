using UnityEngine;
using System.Collections;

public class MPHActionRotate : MPHInteractableAction
{
    public Transform _pos1;
    public Transform _pos2;
    public GameObject _target;
    public int _nextPos = 2;

    public override void DoAction()
    {
        if (_nextPos == 1)
        {
            _target.transform.rotation = _pos1.rotation;
        }
        else
        {
            _target.transform.rotation = _pos2.rotation;
        }

        _nextPos = 3 - _nextPos;
    }
}
