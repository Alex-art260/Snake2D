using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] GameObject snike;
    [SerializeField] GameObject _food;
    [SerializeField] GameObject foodPosition;
    public bool checkSpawn;

    private void Awake()
    {
        Vector3Int position = new Vector3Int(Random.Range(-9, 29), Random.Range(1, 19), 0);
        GameObject food = Instantiate(_food, position, Quaternion.identity);
    }


    public void SpawnFood()
    {
        Vector3Int position = new Vector3Int(Random.Range(-10, 30), Random.Range(0, 20), 0);
        GameObject food = Instantiate(_food, position, Quaternion.identity);
    }

   
}
