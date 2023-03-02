using System;
using UnityEngine;

public class ObstacleLimitPosition : MonoBehaviour
{
    public static Action<Transform> LimitPosition;

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(Constants.OBSTACLE))
        {
            LimitPosition?.Invoke(other.gameObject.transform.parent.transform);
        }    
    }
}
