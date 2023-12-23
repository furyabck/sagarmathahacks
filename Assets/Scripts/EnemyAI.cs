using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    
    public float movespeed, runspeed;
    private Animator anim;
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool PlayerInSightRange, playerInattackrange;

    private void Awake()
    {

        player = GameObject.Find("InkiHero").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        PlayerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInattackrange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        

        if(!PlayerInSightRange && !playerInattackrange)
        {
            anim.SetBool("ismoving", true);
            anim.SetBool("isruuning", false);
            anim.SetBool("isattack", false);
            agent.speed = movespeed;
            Patrolling();

        }
        if(PlayerInSightRange && !playerInattackrange)
        {
            anim.SetBool("ismoving", false);
            anim.SetBool("isruuning", true);
            anim.SetBool("isattack", false);
            agent.speed = runspeed;
            ChasePlayer();
        }
        if(playerInattackrange && PlayerInSightRange)
        {
            
            AttackPlayer();
        }
        
    }
    void Patrolling()
    {
       
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distancetowalkpoint = transform.position - walkPoint;

        if (distancetowalkpoint.magnitude < 1f)
            walkPointSet = false;
    }
    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
        
    }
    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        
        if (!alreadyAttacked)
        {

            //attack code here
            PlayerInfo.isattackingyes = true;
            anim.SetBool("ismoving", false);
            anim.SetBool("isruuning", false);
            anim.SetBool("isattack", true);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
        PlayerInfo.isattackingyes = false;
    }
}
