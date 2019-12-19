using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.AI;


public class PlayerHealth : MonoBehaviour
{
    public float startingHealth = 100;
    public float currentHealth;

    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    public Image healthBar;
    public GameObject End;
    //private float health;

    Animator anim;
    AudioSource playerAudio;
   //PlayerMovement playerMovement;
    //PlayerShooting playerShooting;
    bool isDead;
    bool damaged;

    //ParticleSystem hitParticles;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        //playerMovement = GetComponent <PlayerMovement> ();
        //playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;

        //hitParticles = GetComponentInChildren<ParticleSystem>();
      }


    void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
                damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        if (currentHealth == 0)
            End.SetActive(true);
    }


    public void TakeDamage (int amount)
    {
        if (isDead)
            return;

        HpManager.hp -= amount;
        damaged = true;
            
        currentHealth -= amount;
        Debug.Log("currenthealth is "+currentHealth);

        //hitParticles.transform.position = hitPoint;
       //hitParticles.Play();

        healthBar.fillAmount = currentHealth / startingHealth;
        //Debug.Log(healthBar.fillAmount);

        playerAudio.Play ();

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
            Debug.Log("Player dead");
        }
    }


    void Death ()
    {
        isDead = true;

        //playerShooting.DisableEffects ();

        anim.SetTrigger ("Die");

        //playerAudio.clip = deathClip;
        //playerAudio.Play ();

        //playerMovement.enabled = false;
        //playerShooting.enabled = false;
    }


    public void RestartLevel ()
    {
        SceneManager.LoadScene (0);
    }
}
