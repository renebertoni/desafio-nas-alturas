using UnityEngine;

public class Hand : MonoBehaviour
{
    float _timeToDisable = 2f;

    void Start()
    {
        Invoke("HandDisable", _timeToDisable);
    }

    void HandDisable()
    {
        this.gameObject.SetActive(false);
    }
}
