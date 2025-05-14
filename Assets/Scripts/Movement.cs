using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private int _speed = 3;

    private void Update()
    {
        transform.Translate(_direction * Time.deltaTime * _speed);
    }

    public void Initialize(Vector3 direction)
    {
        _direction = direction;
    }
}
