using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwatHealth : MonoBehaviour
{
    public float hitPoint = 50f;
    Animator anim;
    //NavMeshAgent nav;

    public bool isDead;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        //nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        isDead = false;
    }

    public void ApplyDamage(float damage) {
        hitPoint -= damage;
        if(hitPoint <= 0) {
            isDead = true;
            anim.SetTrigger("Dead");

            this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);

        }
    }
}
