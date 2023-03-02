using UnityEngine;

public class GroundHandler : MonoBehaviour
{
    Collider2D _groundHandlerCollider;

    void Awake()
    {
        _groundHandlerCollider = GetComponent<Collider2D>();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(Constants.GROUND))
        {
            other.gameObject.transform.position = new Vector3(_groundHandlerCollider.bounds.size.x, transform.position.y, transform.position.z);
        }    
    }
}
