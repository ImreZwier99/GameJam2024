using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private GameObject[] Player;
    public GameObject Enemy;
    private Transform targetedEnemy;
    public int RotationSpeed = 10;
    public int Health = 50;
    public int StoppingDistance = 5;
    public GameObject enemy;
    private NavMeshAgent agent;
    private bool isDead;

    private WaveSpawner waveSpawner;

    Collider[] colliders;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectsWithTag("Player");
        targetedEnemy = Player[Random.Range(0, Player.Length)].transform;

        waveSpawner = GetComponentInParent<WaveSpawner>();
    }

    void Update()
    {
        if (!isDead)
        {
            agent.SetDestination(targetedEnemy.position);          
            Vector3 directionToTarget = (targetedEnemy.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            targetRotation.x = 0f;
            targetRotation.z = 0f;
            float rotationAngle = Quaternion.Angle(transform.rotation, targetRotation);
            float rotationSpeedMultiplier = Mathf.Clamp01(rotationAngle / 180f);


            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * rotationSpeedMultiplier * Time.deltaTime);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("weapon"))
        {
            Health -= 25;
            if (Health <= 0 && !isDead)
            {
                EnemyDead();
            }
        }
    }

    public void EnemyDead()
    {
        isDead = true;
        agent.enabled = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<EnemyDieTimer>().enabled = true;
        GetComponent<BoxCollider>().enabled = false;

        waveSpawner.waves[waveSpawner.currentWaveIndex].enemiesLeft--;

        colliders = enemy.GetComponentsInChildren<Collider>();
        foreach (Collider col in colliders)
        {
            col.enabled = true;
        }
    }
}
