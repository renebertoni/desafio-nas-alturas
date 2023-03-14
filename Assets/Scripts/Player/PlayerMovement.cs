using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _playerRigidbody;
    [SerializeField] float _force;
    bool _isMoving;
    GameObject _player;
    Vector3 _startPosition;

    void Awake()
    {
        this._player = gameObject;
        _startPosition = transform.position;
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        PlayerInputs.Fly += DoFly;
    }
    void OnDisable()
    {
        PlayerInputs.Fly -= DoFly;
    }

    void Update()
    {
        var rotation = new Vector3(transform.rotation.x, transform.rotation.y , _playerRigidbody.velocity.y * 2);
        transform.rotation = Quaternion.Euler(rotation);
    }

    void DoFly(GameObject sender)
    {
        if(sender == this._player)
        {
            _playerRigidbody.velocity = Vector2.zero;
            _playerRigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
        }
    }

    public void RestartPosition()
    {
        transform.position = _startPosition;
    }
}
