using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    private Animator anim;

    public void Awake()
    {
        this.anim = this.GetComponent<Animator>();    
    }

    public void TakeDamage(float amount)
    {
        this.health -= amount;

        print("Enemy took some damage, current health = " + this.health);
        if(this.health <= 0)
        {
            this.anim.SetBool("Death", true);
        }
    }
}
