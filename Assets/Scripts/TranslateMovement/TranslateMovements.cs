using UnityEngine;

public class TranslateMovements : MonoBehaviour
{
    [SerializeField] protected float _speed;

    protected void FixedUpdate()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
