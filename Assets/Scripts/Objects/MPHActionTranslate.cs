using UnityEngine;
using System.Collections;

public class MPHActionTranslate : MPHInteractableAction
{
    public Transform _pos1;
    public Transform _pos2;
    public GameObject _target;
    public int _nextPos = 2;
    public float _speed = 0.5f;
    public bool _isActive = false;

    public override void DoAction()
    {
        _isActive = !_isActive;
    }

    void Update()
    {
        if (_isActive)
        {
            Transform nextTransform;
            if (_nextPos == 1)
            {
                nextTransform = _pos1;
            }
            else
            {
                nextTransform = _pos2;
            }

            Vector3 translation = nextTransform.position - _target.transform.position;

            if (translation.magnitude < _speed* Time.deltaTime)
            {
                _nextPos = 3 - _nextPos;
                _target.transform.position = nextTransform.position;
            }
            else
            {
                _target.transform.position += translation.normalized * _speed * Time.deltaTime;
            }
        }
    }
}
