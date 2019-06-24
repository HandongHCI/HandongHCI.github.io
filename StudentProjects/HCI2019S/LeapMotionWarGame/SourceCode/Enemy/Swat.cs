using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Swat : MonoBehaviour
{
    public float timeBetweenAttacks = 0.1f;

    private Animator anim;

    public AudioSource audio = null;
    public AudioClip DeathSound = null;

    public Transform player;
    public NavMeshAgent nav;
    PlayerHealth playerHealth;
   

    private int attackDamage = 10;

    public float AttackDistance = 7.0f;
    public float FllowDistance = 10.0f;

    float HitAccuracy = 1.0f;

    public float swatHealth = 50f;

    float timer;

    //public Transform shootPoint;
    //float range = 5.0f;
   // public ParticleSystem muzzleFlash;

    public AudioClip GunSound = null;

    // Start is called before the first frame update
    void Awake()
    {
       
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (nav.enabled)
        {
            float dist = Vector3.Distance(player.position, this.transform.position);
            bool shoot = false;
            bool follow = (dist < FllowDistance && playerHealth.currentHealth > 0 && swatHealth > 0);
            anim.SetBool("Shoot", shoot);

          


            if (follow)
            {
                if (timer >= timeBetweenAttacks && dist < AttackDistance)
                {
                    shoot = true;
                }
            }



            if (playerHealth.currentHealth <= 0)
            {
                anim.SetTrigger("PlayerDead");
            }

            /*if (!follow && !shoot)
            {
                nav.SetDestination(player.position);
            }*/
            if (follow && !shoot)
            {
                nav.SetDestination(player.position);
            }

            anim.SetBool("Run", follow);
            anim.SetBool("Shoot", shoot);
        }

    }

    public void ShootEvent()
    {
        timer = 0f;

        float random = Random.Range(0.1f, 1.0f);

        // The higher the accuracy is, the more likely the player will be hit
         bool isHit = random > 1.0f - HitAccuracy;


        if (isHit && playerHealth.currentHealth > 0)
        {
           
            audio.PlayOneShot(GunSound);
          
            playerHealth.TakeDamage(attackDamage);
                
        }

    }

    public void ApplyDamage(float damage)
    {
        swatHealth -= damage;
        if (swatHealth <= 0)
        {
            anim.SetTrigger("Dead");

            this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
            nav.enabled = false;
        }
    }


}
