using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform Player;
    public NavMeshAgent Enemy;
    public float Speed;
    public bool isDead;
    public int Health = 50;
    void Update()
    {
        Enemy.SetDestination(Player.position);
        EnemyDead();
        Health = 50;
    }
    public void EnemyDead()
    {
        //if (Health == 0)
        //{
        //    isDead = true;
        //}
        
        if (isDead == true)
        {
            GetComponent<NavMeshAgent>().speed = 0;
            GetComponent<Animator>().enabled = false;
            GetComponent<EnemyDieTimer>().enabled = true;
        }
    }
}
