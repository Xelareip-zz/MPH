using UnityEngine;
using System.Collections;

public class MPHActionGlove : MPHInteractableAction
{
    public float _strength = 30;
    public Rigidbody2D _glove;
    private Vector3 _initialPosition;
    public float _resetDelay;

    public override void DoAction()
    {
        _glove.isKinematic = false;
        _glove.AddForce((_glove.transform.position - transform.position).normalized * _strength);

        RestartInDelay();
    }

    void Start()
    {
        _initialPosition = _glove.transform.position;
    }

    public void RestartInDelay()
    {
        StartCoroutine(RestartInDelayCoroutine());
    }

    IEnumerator RestartInDelayCoroutine()
    {
        yield return new WaitForSeconds(_resetDelay);
        _glove.transform.position = _initialPosition;
        _glove.velocity = Vector2.zero;
        _glove.isKinematic = true;
    }
}
