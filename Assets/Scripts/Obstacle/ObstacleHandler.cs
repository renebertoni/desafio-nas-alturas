using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleHandler : MonoBehaviour
{
    [SerializeField] GameObject _obstacle;
    [SerializeField] int maxObstacles;
    [SerializeField] float _heightOffset;
    [SerializeField] float _timeToCreateObstacle;
    [SerializeField] float _obstacleSpeed;
    List<GameObject> _generatedObstacles = new List<GameObject>();
    Vector3 _startPosition;

    void Awake()
    {
        var limitSize = TryGetComponent<Collider2D>(out Collider2D limitCollider) ? limitCollider.bounds.size.x : 0;
        _startPosition = new Vector3(transform.position.x + limitSize, transform.position.y, transform.position.z);
    }

    void Start()
    {
        GenerateObstacles();
    }

    public void GenerateObstacles()
    {
        DestroyObstacles();
        for (int i = 0; i < maxObstacles; i++)
        {
            StartCoroutine(CreateObstacle(i));
        }
    }

    void DestroyObstacles()
    {
        foreach (var obstacle in _generatedObstacles)
        {
            Destroy(obstacle);
        }
        _generatedObstacles.Clear();
    }

    IEnumerator CreateObstacle(int index)
    {
        yield return new WaitForSeconds(_timeToCreateObstacle * index);
        var obstacle = Instantiate<GameObject>(_obstacle, RandomHeight(), Quaternion.identity);
        obstacle.GetComponent<Translation>().Speed = _obstacleSpeed;
        _generatedObstacles.Add(obstacle);
    }

    void ResetPosition(Transform obstacleTransform)
    {
        obstacleTransform.position = RandomHeight();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(Constants.OBSTACLE))
        {
            ResetPosition(other.gameObject.transform);
        }    
    }

    Vector3 RandomHeight()
    {
        var randomHeight = Random.Range(-_heightOffset, _heightOffset);
        return new Vector3(_startPosition.x, _startPosition.y + randomHeight, _startPosition.z);
    }

    public void DisableObstacles()
    {
        StopAllCoroutines();
        foreach (var obstacle in _generatedObstacles)
        {
            obstacle.GetComponent<Translation>().ToggleMovement(false);
        }
    }
}
