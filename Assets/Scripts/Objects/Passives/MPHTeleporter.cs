using UnityEngine;
using System.Collections;

public class MPHTeleporter : MonoBehaviour
{
    public Rigidbody2D _target;
    public MPHTeleporter _endPoint;
    public bool _isActive;

    private Rigidbody2D GetBall()
    {
        if (_target == null)
        {
            _target = MPHBall.Instance.GetComponent<Rigidbody2D>();
        }
        return _target;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (_isActive && coll.gameObject == GetBall().gameObject)
        {
            GetBall().transform.position = _endPoint.transform.position;
            _endPoint._isActive = false;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        _isActive = true;
    }
}
