using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombi : MonoBehaviour
{
    Player player;
    NavMeshAgent navMeshAgent;
    CapsuleCollider capsuleCollider;
    bool dead;
    Animator animator;
    MovementAnimator movement;
    public int health;
    public new  ParticleSystem  particleSystem;
    void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        player = FindObjectOfType<Player>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        movement = GetComponent<MovementAnimator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            return;
        }
        if (player != null)
            navMeshAgent.SetDestination(player.transform.position);


    }

    public void Kill()
    {
        
        if (!dead)
        {
            particleSystem.Play();


            if (health == 0)
            {
                dead = true;
                Destroy(capsuleCollider);
                Destroy(movement);
                Destroy(navMeshAgent);
                animator.SetTrigger("died");
            }
            else
            {


                health -= 100;

            }




        }

    }
}
