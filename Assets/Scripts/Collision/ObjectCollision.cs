using UnityEngine;
using System;

public class ObjectCollision : MonoBehaviour
{
    public static Action Crash;

    void OnCollisionEnter2D(Collision2D other)
    {
        var otherGameObjetc = other.gameObject;

        if( otherGameObjetc.CompareTag(Constants.PLAYER) )
        {
            Crash?.Invoke();    
        }
    }
}
