﻿using UnityEngine;
using System.Collections.Generic;

public class MPHInteractableObject : MonoBehaviour
{
    public MPHInteractableAction _action;
    public List<Collider2D> _colliders;

    void Start()
    {
        _colliders = new List<Collider2D>();
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        _colliders.AddRange(colliders);
        _action = GetComponent<MPHInteractableAction>();
        MPHInteractableManager.Instance.RegisterInteractable(this);
    }

    public void Touched()
    {
        _action.DoAction();
    }
}
