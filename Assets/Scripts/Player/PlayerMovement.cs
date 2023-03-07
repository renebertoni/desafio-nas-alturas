using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _playerRigidbody;
    [SerializeField] float _force;
    bool _isMoving;

    void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        PlayerInputs.Fly += OnFly;
        GameHandler.GameOver += ToggleMovement;
    }
    void OnDisable()
    {
        PlayerInputs.Fly -= OnFly;
        GameHandler.GameOver -= ToggleMovement;
    }

    void OnFly()
    {
        _playerRigidbody.velocity = Vector2.zero;
        _playerRigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
    }

    void ToggleMovement(int recordScore)
    {
        _playerRigidbody.simulated = _isMoving;
    }
}
