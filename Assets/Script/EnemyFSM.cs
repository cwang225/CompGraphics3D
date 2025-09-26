using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{

    public enum EnemyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer };
    public EnemyState currentState;
    public Sight sightSensor;
    private NavMeshAgent agent;
    public GameObject bulletPrefab;
    public float lastShootTime;
    public float fireRate;
    // Start is called before the first frame update

    private void Awake()
    {
        baseTransform = GameObject.Find("BaseDamagePoint").transform;
        agent = GetComponentInParent<NavMeshAgent>();
    }
    void OnDrawGizmos()
    {
        // atack chase gototo base
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }


    // Update is called once per frame
    void Update()
    {
        if (currentState == EnemyState.GoToBase)
        {
            GoToBase();
        }
        else if (currentState == EnemyState.AttackBase)
        {
            AttackBase();
        }
        else if (currentState == EnemyState.ChasePlayer)
        {
            ChasePlayer();
        }
        else
        {
            AttackPlayer();
        }

    }

    public Transform baseTransform;
    public float baseAttackDistance;
    void GoToBase()
    {
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);
        if (sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;
        }
        float distanceToBase = UnityEngine.Vector3.Distance(
            transform.position, baseTransform.position
        );
        if (distanceToBase < baseAttackDistance)
        {
            currentState = EnemyState.AttackBase;
        }
    }
    void AttackBase()
    {
        agent.isStopped = true;
        LookTo(baseTransform.position);
        Shoot();
    }

    public float playerAttackDistance;
    void ChasePlayer()
    {
        agent.isStopped = false;
        if (sightSensor.detectedObject != null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        agent.SetDestination(sightSensor.detectedObject.transform.position);
        float distanceToPlayer = UnityEngine.Vector3.Distance(
            transform.position, sightSensor.detectedObject.transform.position
        );
        if (distanceToPlayer <= playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }
    void AttackPlayer()
    {
        agent.isStopped = true;
        if (sightSensor.detectedObject != null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        
        LookTo(sightSensor.detectedObject.transform.position);
        Shoot();
        float distanceToPlayer = UnityEngine.Vector3.Distance(
            transform.position, sightSensor.detectedObject.transform.position
        );
        if (distanceToPlayer > playerAttackDistance * 1.1f)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }

    void Shoot()
    {
        var timeSinceLastShoot = Time.time - lastShootTime;
        if (timeSinceLastShoot > fireRate)
        {
            lastShootTime = Time.time;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }

    void LookTo(Vector3 targetPosition)
    {
        Vector3 directionToPosition = Vector3.Normalize(
            targetPosition = transform.parent.position
        );
        directionToPosition.y = 0;
        transform.parent.forward = directionToPosition;
    }
}
