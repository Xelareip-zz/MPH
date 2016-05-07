using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MPHActionMagnet : MPHInteractableAction
{
    public Rigidbody2D _target;
    public float _strength;
    public float _range;
    public bool _isActive = false;

    public override void DoAction()
    {
        _isActive = !_isActive;
    }

    void Update()
    {
        if (_isActive)
        {
            float distance = Vector3.Distance(_target.transform.position, transform.position);
            if (distance < _range)
            {
                Vector2 force = transform.position - _target.transform.position;
                force = force.normalized * ((_range - distance) / _range) * _strength * Time.deltaTime;
                _target.AddForce(force);
            }
        }
    }


#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        float angleIncrement = Mathf.PI / 50;
        for (int i = 0; i < 100; ++i)
        {
            float angle = angleIncrement * i;
            Gizmos.DrawLine(
                transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0.0f) * _range, 
                transform.position + new Vector3(Mathf.Cos(angle + angleIncrement), Mathf.Sin(angle + angleIncrement), 0.0f) * _range);
        }
        SceneView.RepaintAll();
    }
#endif //UNITY_EDITOR
}
