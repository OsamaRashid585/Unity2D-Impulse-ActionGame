using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefab;
    void Start()
    {
        InvokeRepeating("SpwanEnemyes", 1, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpwanEnemyes()
    {
        for(int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    var pos0 = new Vector2(11, 3);
                    Instantiate(_enemyPrefab[0], pos0, Quaternion.identity);
                break;
                case 1:
                    var pos1 = new Vector2(-11, -3);
                    Instantiate(_enemyPrefab[0], pos1, Quaternion.identity);
                    break;
                case 2:
                    var pos2 = new Vector2(-11, 3);
                    Instantiate(_enemyPrefab[0], pos2, Quaternion.identity);
                    break;
                case 3:
                    var pos3 = new Vector2(11, -3);
                    Instantiate(_enemyPrefab[0], pos3, Quaternion.identity);
                    break;

            }
        }
    }

}
