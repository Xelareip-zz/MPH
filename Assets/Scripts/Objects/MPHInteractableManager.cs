using UnityEngine;
using System.Collections.Generic;

public class MPHInteractableManager : MonoBehaviour
{
    private static MPHInteractableManager _instance;
    public static MPHInteractableManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MPHInteractableManager>();
            }
            return _instance;
        }
    }

    public List<MPHInteractableObject> _registeredObjects;

    void Update()
    {
        Vector2 initPosition = new Vector2(float.MinValue, float.MinValue);
        Vector2 position = initPosition;
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            position = Input.mousePosition;
        }
#endif
        if (Input.touchCount == 1)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                position = Input.touches[0].position;
            }
        }

        if (position == initPosition)
        {
            return;
        }
        position = MPHUtils.ScreenToWorld(position);

        foreach (MPHInteractableObject current in _registeredObjects)
        {
            foreach (Collider2D coll in current._colliders)
            {
                if (coll.OverlapPoint(position))
                {
                    current.Touched();
                    return;
                }
            }
        }
    }

    public void RegisterInteractable(MPHInteractableObject interactable)
    {
        if (_registeredObjects.Contains(interactable) == false)
        {
            _registeredObjects.Add(interactable);
        }
    }
}
