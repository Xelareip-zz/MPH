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

    
	void Start ()
    {
        _instance = this;
	}
	
}
