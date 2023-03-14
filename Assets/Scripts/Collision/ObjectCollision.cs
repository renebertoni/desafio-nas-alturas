using UnityEngine;
using System;

public class ObjectCollision : MonoBehaviour
{
    public static Action<GameObject> Crash;

    void OnCollisionEnter2D(Collision2D other)
    {
        var otherGameObject = other.gameObject;

        if( otherGameObject.CompareTag(Constants.PLAYER) )
        {
            Crash?.Invoke(otherGameObject);    
        }
    }
}
