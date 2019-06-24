using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    NavMeshAgent nav;

    private Animator anim;

    /*public float AttackDistance = 10.0f;
    public float FllowDistance = 20.0f;*/

    //Animator anim;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
      //  anim.SetBool("Run", true);
        nav.SetDestination(player.position);
        Debug.Log("player pos: " + player.position + "swat pos: " + nav.destination);
 
    }
}
