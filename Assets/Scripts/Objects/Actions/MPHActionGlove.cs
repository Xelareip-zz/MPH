using UnityEngine;
using System.Collections;

public class MPHActionGlove : MPHInteractableAction
{
    public float _strength = 30;
    public Rigidbody2D _glove;

    public override void DoAction()
    {
        _glove.isKinematic = false;
        _glove.AddForce((_glove.transform.position - transform.position).normalized * _strength);
    }
}
