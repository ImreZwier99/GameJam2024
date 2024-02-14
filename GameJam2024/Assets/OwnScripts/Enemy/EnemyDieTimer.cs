using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieTimer : MonoBehaviour
{
    public float timer = 3;
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
