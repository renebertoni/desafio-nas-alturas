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
        GameHandler.GameOver += StopMovement;
    }
    void OnDisable()
    {
        PlayerInputs.Fly -= OnFly;
        GameHandler.GameOver -= StopMovement;
    }

    void OnFly()
    {
        _playerRigidbody.velocity = Vector2.zero;
        _playerRigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
    }

    void StopMovement()
    {
        _playerRigidbody.simulated = false;
    }
}
