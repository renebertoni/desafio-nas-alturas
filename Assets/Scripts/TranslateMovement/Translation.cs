using UnityEngine;

public class Translation : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _offSet;
    [SerializeField] bool _isObstacle;
    Vector3 _startPosition;
    float _scale;
    float _realSize;

    void Awake()
    {
        _startPosition = transform.position;
        _scale = transform.localScale.x;

        var width = TryGetComponent<SpriteRenderer>(out SpriteRenderer sRenderer) ? sRenderer.size.x : 1 ;
        _realSize = (float)width * _scale + _offSet;
    } 

    void FixedUpdate()
    {
        if(_isObstacle)
            ObstacleTranslate();
        else
            EnviromentTranslate();
    }

    void EnviromentTranslate()
    {
        var offsset = Mathf.Repeat(_speed * Time.time, _realSize/2f + _offSet);
        transform.position = _startPosition + (Vector3.left * offsset);
    }

    void ObstacleTranslate()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
