using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    #region
    public enum State { Patrol, Pause, Chase };
    public State state;
    [Header("Pause State")]
    public float pauseLength;
    private float pauseTimer = 0;

    //The node that we are currently following. Set it at edit time to determine the first node.
    public nodeScript nextNode;
    //A reference to the controller so we can call the "move" function
    public CharacterController controller;
    //The speed at which this unit will move towards nextNode
    public float speed;
    //The minimum distance the unit must be from nextNode to move to the next one
    public float minDistance;

    
    public float sightRange;
    public float sightAngle;
    public bool isAttacked;
    public float timeBetweenAttacks;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public NavMeshAgent navAgent;
    public Transform player;
    public LayerMask ground, playerM;

    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttack;
    public bool attacked;
    public float seeRange;
    public float attackRange;
    public bool inSightRange;
    public bool inAttackRange;


    #endregion
    private void Start()
    {
        player = GameObject.Find("player").transform;
        navAgent = GetComponent<NavMeshAgent>();
        controller = GetComponent<CharacterController>();
    }
    private void patrol()
    {
        if (!walkPointSet)
        {
            findWalkPoint();

        }
        if (walkPointSet)
        {
            navAgent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude<1f)
        {
            walkPointSet = false;
        }
    }
    private void findWalkPoint()
    {
        float range1 = Random.Range(-walkPointRange, walkPointRange);
        float range2 = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x+range2, transform.position.y, transform.position.z+range1);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, ground))
        {
            walkPointSet= true;
        }
    }
    private void goingToPlayer()
    {
        navAgent.SetDestination(player.position);
    }
    private void attack()
    {
        navAgent.SetDestination(transform.position);
        transform.LookAt(player);
        if (!attacked)
        {
            // attack code
            Rigidbody rb = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody>();    
            rb.AddForce(transform.forward, ForceMode.Impulse); 
            attacked = true;
            Invoke(nameof(resetAttack), timeBetweenAttacks);
        }
    }
    private void resetAttack()
    {
        attacked=false; 
    }
    
    private void Update()
    {
       
        inSightRange = Physics.CheckSphere(transform.position, seeRange, playerM);
        inAttackRange = Physics.CheckSphere(transform.position, attackRange, playerM);

        if (!inSightRange && !inAttackRange)
        {
            patrol();
        }
        if (inSightRange && !inAttackRange)
        {
            goingToPlayer();
        }
        if (inSightRange && inAttackRange)
        {
            attack();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
