using UnityEngine;
using System.Collections;

public class MPHActionDisappear : MPHInteractableAction
{
    public GameObject _fullObject;
    public GameObject _movingObject;
    public bool _activable;

    public override void DoAction()
    {
        if (_activable || _fullObject.activeInHierarchy)
        {
            _fullObject.SetActive(!_fullObject.activeInHierarchy);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject == _movingObject)
        {
            _activable = false;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject == _movingObject)
        {
            _activable = true;
        }
    }
}
