using UnityEngine;
using System.Collections;

public class MPHBall : MonoBehaviour
{
    private static MPHBall _instance;
    public static MPHBall Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MPHBall>();
            }
            return _instance;
        }
    }

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    public float _angularSpeedTrigger;
    public float _speedTrigger;
    public Sprite _stoppedSprite;
    public Sprite _normalSprite;
    
	void Start ()
    {
        _instance = this;
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (_rigidbody.velocity.magnitude < _speedTrigger && Mathf.Abs(_rigidbody.angularVelocity) < _angularSpeedTrigger)
        {
            _renderer.sprite = _stoppedSprite;
        }
        else
        {
            _renderer.sprite = _normalSprite;
        }
    }
	
}
