using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    [SerializeField] GameObject _obstacle;
    [SerializeField] int maxObstacles;

    void Awake()
    {
        for (int i = 1; i <= maxObstacles; i++)
        {
            Instantiate<GameObject>(_obstacle, transform.position * i, Quaternion.identity);
        }
    }
    void OnEnable()
    {
        ObstacleLimitPosition.LimitPosition += OnLimitePosition;
    }

    void OnDisable()
    {
        ObstacleLimitPosition.LimitPosition -= OnLimitePosition;
    }

    private void OnLimitePosition(Transform obstacle)
    {
        obstacle.position = transform.position;
    }
}
