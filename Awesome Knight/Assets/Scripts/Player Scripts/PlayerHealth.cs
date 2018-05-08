using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 150f;
    public float health = 100f;
    private bool isShielded;
    private Animator anim;

    public bool IsShielded
    {
        get
        {
            return isShielded;
        }

        set
        {
            isShielded = value;
        }
    }

    public void TakeDamage(float amount)
    {
        if(!this.IsShielded)
        {
            this.health -= amount;

            if(this.health <= 0f)
            {
                this.anim.SetBool("Death", true);
            }
        }
    }

	// Use this for initialization
	void Awake ()
    {
        this.anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
