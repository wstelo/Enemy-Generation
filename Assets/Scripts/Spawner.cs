using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Movement _prefab;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    private List<Vector3> _directions = new List<Vector3>();

    private void Start()
    {
        _directions.Add(Vector3.right);
        _directions.Add(Vector3.left);
        _directions.Add(Vector3.forward);
        _directions.Add(Vector3.back);

        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        int timeToSpawn = 2;
        var wait = new WaitForSecondsRealtime(timeToSpawn);

        while (enabled)
        {
            int spawnPointIndex = Random.Range(0, _spawnPoints.Count);
            int directionIndex = Random.Range(0, _directions.Count);

            Movement movement = Instantiate(_prefab, _spawnPoints[spawnPointIndex].transform.position, Quaternion.identity,transform);
            movement.Initialize(_directions[directionIndex]);
            yield return wait;
        }
    }
}
