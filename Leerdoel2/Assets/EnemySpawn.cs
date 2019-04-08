using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    Object floor;
    Object air;
    Object low;
    int buffer;
    void Start()
    {
        floor = Resources.Load("prefs/Floor Enemy");
        air = Resources.Load("prefs/Air Enemy");
        low = Resources.Load("prefs/Air Enemy");
        buffer = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (buffer > 0)
        {
            buffer--;
        }
        if (buffer == 0)
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    Instantiate(floor, transform.position, Quaternion.identity, transform);
                    break;
                case 1:
                    Instantiate(air, new Vector3(transform.position.x,  1.0f, transform.position.z), Quaternion.identity, transform);
                    break;
                case 2:
                    Instantiate(air, new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.identity, transform);
                    break;
            }
            buffer = 120;
        }
    }
}
