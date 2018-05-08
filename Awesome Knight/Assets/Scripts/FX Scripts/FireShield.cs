using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShield : MonoBehaviour
{
    // Use this for initialization
    private PlayerHealth playerHealth;

	void Awake ()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        this.playerHealth = player.GetComponent<PlayerHealth>();
	}

    private void OnEnable()
    {
        this.playerHealth.IsShielded = true;
        print("Player shielded");
    }

    private void OnDisable()
    {
        this.playerHealth.IsShielded = false;
        print("Player shielded");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
