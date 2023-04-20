using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
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
    
    public GameObject player;
    public float sightRange;
    public float sightAngle;



    private void Start()
    {
        
        controller = GetComponent<CharacterController>();
    }


    private void Update()
    {
        //If there's no next node, this unit will not move
        if (nextNode == null)
            return;
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
        pauseTimer = Time.deltaTime;
    }
    void chase()
    {
        //this.gameObject
    }
}
