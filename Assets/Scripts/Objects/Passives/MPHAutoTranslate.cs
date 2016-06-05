using UnityEngine;
using System.Collections;

public class MPHAutoTranslate : MonoBehaviour
{
    private Vector3 _pos1;
    public Transform _pos2;
    public GameObject _target;
    private SliderJoint2D _sliderJoint;
    public int _nextPos = 2;
    public float _speed = 0.5f;
    
    void Start()
    {
        _pos1 = transform.position;
        _sliderJoint = _target.GetComponent<SliderJoint2D>();
        JointTranslationLimits2D limits = _sliderJoint.limits;
        limits.min = -Vector3.Distance(transform.position, _pos2.position);
        limits.max = 0.0f;
        _sliderJoint.limits = limits;
        _sliderJoint.angle = Vector3.Angle(Vector3.right, _pos2.position - transform.position);
        JointMotor2D motor = _sliderJoint.motor;
        motor.motorSpeed = -_speed;
        _sliderJoint.motor = motor;
    }

    void Update()
    {
        Vector3 nextPosition;
        if (_nextPos == 1)
        {
            nextPosition = _pos1;
        }
        else
        {
            nextPosition = _pos2.position;
        }

        Vector3 translation = nextPosition - _target.transform.position;

        if (translation.magnitude < _speed * Time.deltaTime)
        {
            _nextPos = 3 - _nextPos;
            // _target.transform.position = nextPosition;
            JointMotor2D motor = _sliderJoint.motor;
            motor.motorSpeed *= -1.0f;
            _sliderJoint.motor = motor;
        }/*
        else
        {
            _target.transform.position += translation.normalized * _speed * Time.deltaTime;
        }*/
    }
}
