using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public float Speed = 0.001f;
    public bool isDead;
    public int Health = 50;
    Collider[] colliders;
    public GameObject enemy;
    void Update()
    {
        Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, Player.transform.position, Speed);
        //Enemy.SetDestination(Player.position);
        //Health = 50;
        colliders = enemy.GetComponentsInChildren<Collider>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "weapon")
        {
            Health -= 25;
            EnemyDead();
        }
    }
    public void EnemyDead()
    {
        if (Health == 0)
        {
            //GetComponent<NavMeshAgent>().speed = 0;
            Speed = 0;
            GetComponent<Animator>().enabled = false;
            GetComponent<EnemyDieTimer>().enabled = true;
            GetComponent<BoxCollider>().enabled = false;

            foreach (Collider col in colliders)
            {
                col.enabled = true;
            }
        }
    }
}
