using UnityEngine;
using System.Collections;

public class MPHTutorialObject : MonoBehaviour
{
    public MPHInteractableObject _objectToTouch;
    public int _numberOfTouches = 1;

    void Start()
    {
        _objectToTouch._touched += ObjectTouched;
    }

    public void ObjectTouched()
    {
        --_numberOfTouches;
        if (_numberOfTouches <= 0)
        {
            _objectToTouch._touched -= ObjectTouched;
            Destroy(gameObject);
        }
    }

}
