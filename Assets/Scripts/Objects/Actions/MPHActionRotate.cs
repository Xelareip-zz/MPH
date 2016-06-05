using UnityEngine;
using System.Collections;


public class MPHActionRotate : MPHInteractableAction
{
    public Transform _pos1;
    public Transform _pos2;
    public float _targetAngle;
    public HingeJoint2D _target;
    public float _maxRotationSpeed;
    public int _nextPos = 2;
    
    void Start()
    {
        JointAngleLimits2D limits = new JointAngleLimits2D();
        limits.min = 0.0f;
        limits.max = _targetAngle;
        _target.limits = limits;
    }

    void Update()
    {
        float targetAngle = 0.0f;
        if (_nextPos == 2)
        {
            targetAngle = _targetAngle;
        }
        targetAngle = (-targetAngle + 360) % 360;
        
        float currentAngle = _target.transform.localEulerAngles.z;
        
        float startSlowAngle = _maxRotationSpeed;
        float speed = _target.motor.motorSpeed;
        float angleDifference = Mathf.Min(Mathf.Abs(targetAngle - currentAngle), Mathf.Abs(targetAngle - currentAngle + 360));

        float speedDirection = 1.0f;
        if (speed < 0.0f)
        {
            speedDirection = -1.0f;
        }
        /*
        speed = speedDirection * Mathf.Max(1.0f, Mathf.Min(90.0f, 10.0f * _maxRotationSpeed * angleDifference / startSlowAngle));
        if (angleDifference < startSlowAngle)
        {
            speed = speedDirection * Mathf.Max(1.0f, _maxRotationSpeed * angleDifference / startSlowAngle);
        }*/
        speed = speedDirection * 2.0f * _maxRotationSpeed * angleDifference / startSlowAngle;

        ChangeMotorSpeed(speed);
    }

    private void ChangeMotorSpeed(float speed)
    {
        JointMotor2D motor = _target.motor;
        motor.motorSpeed = speed;
        _target.motor = motor;
    }

    public override void DoAction()
    {
        JointMotor2D motor = _target.motor;

        float speedDirection = 1.0f;
        if (motor.motorSpeed > 0.0f)
        {
            speedDirection = -1.0f;
        }

        motor.motorSpeed = speedDirection * _maxRotationSpeed;
        _target.motor = motor;
        _nextPos = 3 - _nextPos;
    }
}
