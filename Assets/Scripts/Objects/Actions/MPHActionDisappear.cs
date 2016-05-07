using UnityEngine;
using System.Collections;

public class MPHActionDisappear : MPHInteractableAction
{
    public GameObject _fullObject;
    public GameObject _movingObject;
    public bool _usable;

    public override void DoAction()
    {
        if (_usable)
        {
            _fullObject.SetActive(!_fullObject.activeInHierarchy);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject == _movingObject)
        {
            _usable = false;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject == _movingObject)
        {
            _usable = true;
        }
    }
}
