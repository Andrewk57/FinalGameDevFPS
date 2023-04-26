using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public enum State { Patrol, Pause, Chase };
    public State state;
    [Header("Pause State")]
    public float pauseLength;
    private float pauseTimer = 1;

    //The node that we are currently following. Set it at edit time to determine the first node.
    public nodeScript nextNode;
    //A reference to the controller so we can call the "move" function
    public CharacterController controller;
    //The speed at which this unit will move towards nextNode
    public float speed;
    //The minimum distance the unit must be from nextNode to move to the next one
    public float minDistance;
    
    public GameObject player;
    public float sightRange;
    public float sightAngle;
    public bool isAttacked;
    public float timeBetweenAttacks;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public GameObject shootPoint;
    public Animator animator;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }


    private void Update()
    {
        //If there's no next node, this unit will not move
        if (nextNode == null)
        {
            transform.LookAt(player.transform);
            return;
        }
           // return;
        Vector3 movement =
           (nextNode.transform.position - transform.position).normalized
           * speed
           * Time.deltaTime;

        
        controller.Move(movement);

        //If the distance between this unit and nextNode is less than the minimum distance,
        //we get a new nextNode from the current one, by "asking" it what its own "next node" is.
        if (Vector3.Distance(nextNode.transform.position, transform.position) <= minDistance)
        {
            nextNode = nextNode.GetNext();
        }


        if (Vector3.Distance(transform.position, player.transform.position) <= sightRange &&
   Vector3.Angle(transform.forward, player.transform.position - transform.position) <= sightAngle)
        {

            state = State.Chase;
        }

        switch (state)
        {
            case State.Patrol:
                patrol();
                break;
            case State.Pause:
                pause();
                break;
            case State.Chase:
                chase();
                break;
        }
    }
    void patrol()
    {
        //If there's no next node, this unit will not move
        if (nextNode == null)
            return;
        

        Vector3 movement =
            (nextNode.transform.position - transform.position).normalized
            * speed
            * Time.deltaTime;

        //Otherwise, the unit will move in the direction towards its nextNode reference
        controller.Move(movement);

        //If the distance between this unit and nextNode is less than the minimum distance,
        //we get a new nextNode from the current one, by "asking" it what its own "next node" is.
        if (Vector3.Distance(nextNode.transform.position, transform.position) <= minDistance)
        {
            nextNode = nextNode.GetNext();
            // when u get to the next node, pause state is started
            state = State.Pause;
        }
       
    }
    void pause()
    {
        if (pauseTimer >= pauseLength)
        {
            pauseTimer = 0;
            state = State.Patrol;
            return;
        }
        pauseTimer += Time.deltaTime;
    }

    void chase()
    {
        //Debug.Log("Chase started");
       animator.SetBool("isPatrolling", false);
        //Debug.Log("Animation should have stopped");
        nextNode = null;
        // Face the player
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime);

        if (!isAttacked)
        {
            //Debug.Log("Entered");
            StartCoroutine(ResetAndShoot());
        }
    }

    IEnumerator ResetAndShoot()
    {
        ShootBullet();
        Debug.Log("Shot bullet");
        isAttacked = true;
        yield return new WaitForSeconds(timeBetweenAttacks);
        isAttacked = false;
        chase();
    }

    void ShootBullet()
    {
        // Calculate the direction vector pointing towards the player
        Vector3 direction = (player.transform.position - shootPoint.transform.position).normalized;

        // Instantiate the bullet at the shootPoint's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.transform.position, Quaternion.LookRotation(direction));
    }


    void Attacked()
    {
        
        isAttacked = false;
        state = State.Chase;
        Debug.Log("Reset attack");
    }
}
