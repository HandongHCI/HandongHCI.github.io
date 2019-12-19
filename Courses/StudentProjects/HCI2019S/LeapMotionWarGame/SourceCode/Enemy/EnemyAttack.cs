using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    PlayerHealth playerHealth;

    public AudioSource m_Audio = null;
    public float AttackDistance = 5.0f;
    public float FollowDistance = 5.0f;

    Animator anim;
    GameObject player;
   //EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;

    [Range(0.0f, 1.0f)]
    public float AttackProbability = 0.5f;

    [Range(0.0f, 1.0f)]
    public float HitAccuracy = 0.5f;
    public float DamagePoints = 2.0f;
    public AudioClip GunSound = null;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
        m_Audio = GetComponent<AudioSource>();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        float dist = Vector3.Distance(player.transform.position, this.transform.position);
        bool shoot = false;
        bool follow = (dist < FollowDistance);

        if (follow)
        {
            float random = Random.Range(0.0f, 1.0f);
            if (random > (1.0f - AttackProbability) && dist < AttackDistance)
            {
                shoot = true;
            }
        }

        if (timer >= timeBetweenAttacks && shoot/*&& playerInRange && enemyHealth.currentHealth > 0*/)
        {

            Attack ();
        }

        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            Debug.Log("attack");
           //playerHealth.TakeDamage (attackDamage);
            Debug.Log(attackDamage);
        }
    }
}
