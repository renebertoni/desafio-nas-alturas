using UnityEngine;
using System;

public class ObstaclePointField : MonoBehaviour
{
    public static Action AddScore;

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(Constants.PLAYER))
        {
            AddScore?.Invoke();
        }
    }
}
