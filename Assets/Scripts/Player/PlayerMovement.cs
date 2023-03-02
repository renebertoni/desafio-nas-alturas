using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _playerRigidbody;
    [SerializeField] float _force;

    void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        PlayerInputs.Fly += OnFly;    
    }
    void OnDisable()
    {
        PlayerInputs.Fly -= OnFly;    
    }

    void OnFly()
    {
        _playerRigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
    }
}
