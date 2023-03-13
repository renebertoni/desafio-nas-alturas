using UnityEngine;
using System.Collections;

public class ObstacleHandler : MonoBehaviour
{
    [SerializeField] GameObject _obstacle;
    [SerializeField] int maxObstacles;
    [SerializeField] float _heightOffset;
    [SerializeField] float _timeToCreateObstacle;
    Vector3 _startPosition;

    void Awake()
    {
        for (int i = 0; i < maxObstacles; i++)
        {
            StartCoroutine(CreateObstacle(i));
        }
        var limitSize = TryGetComponent<Collider2D>(out Collider2D limitCollider) ? limitCollider.bounds.size.x : 0;
        _startPosition = new Vector3(transform.position.x + limitSize, transform.position.y, transform.position.z);
    }

    IEnumerator CreateObstacle(int index)
    {
        yield return new WaitForSeconds(_timeToCreateObstacle * index);
        var obstacle = Instantiate<GameObject>(_obstacle, RandomHeight(), Quaternion.identity);
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
}
