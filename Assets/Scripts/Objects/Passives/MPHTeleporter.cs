using UnityEngine;
using System.Collections;

public class MPHTeleporter : MonoBehaviour
{
    public Rigidbody2D _target;
    public MPHTeleporter _endPoint;
    public bool _isActive;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (_isActive)
        {
            _target.transform.position = _endPoint.transform.position;
            _endPoint._isActive = false;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        _isActive = true;
    }
}
