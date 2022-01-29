using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MovementAnimator : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Animator animator;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        if (!player.isDead)
        {
            if (player.curentHealth < 0)
            {
                animator.SetTrigger("isDead");

            }
        }
        animator.SetFloat("speed", navMeshAgent.velocity.magnitude);
    }
}
