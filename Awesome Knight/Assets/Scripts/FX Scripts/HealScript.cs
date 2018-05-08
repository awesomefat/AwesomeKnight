using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript : MonoBehaviour
{
    public float healAmount = 20f;

	// Use this for initialization
	void Start ()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth pHealth = player.GetComponent<PlayerHealth>();
        
        if(pHealth.health >= pHealth.maxHealth - this.healAmount)
        {
            pHealth.health = pHealth.maxHealth;
        }
        else
        {
            pHealth.health += this.healAmount;
        }
        print("Player Health: " + pHealth.health);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
