using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _placeZone;
    [SerializeField] private float _speed;

    private Vector3 _placePosition;
    private Transform[] _places;
    private int _index;

    private void Start()
    {
        _places = new Transform[_placeZone.childCount];

        for (int i = 0; i < _places.Length; i++)
            _places[i] = _placeZone.GetChild(i);

        _placePosition = _places[_index].position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _placePosition, _speed * Time.deltaTime);

        if (transform.position == _placePosition)
            _placePosition = GetNextPlace();
    }

    private Vector3 GetNextPlace()
    {
        _index = ++_index % _places.Length;

        Vector3 nextPosition = _places[_index].transform.position;
        transform.forward = nextPosition - transform.position;
        return nextPosition;
    }
}
