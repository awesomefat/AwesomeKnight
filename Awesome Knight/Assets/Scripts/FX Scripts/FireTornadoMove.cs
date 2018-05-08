using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTornadoMove : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float radius = 0.5f;
    public float damageCount = 10f;
    public GameObject fireExplosion;

    private EnemyHealth enemyHealth;
    private bool collided;

    private float speed = 3f;

	// Use this for initialization
	void Start ()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        this.transform.rotation = Quaternion.LookRotation(player.transform.forward);
	}
	
    void CheckForDamage()
    {
        Collider[] hits = Physics.OverlapSphere(this.transform.position, this.radius, this.enemyLayer);
        foreach (Collider c in hits)
        {
            print("found collider");
            this.enemyHealth = c.gameObject.GetComponent<EnemyHealth>();
            this.collided = true;
        }

        if (this.collided)
        {
            this.enemyHealth.TakeDamage(this.damageCount);
            Vector3 temp = this.transform.position;
            temp.y += 2f;
            Instantiate(this.fireExplosion, temp, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void Move()
    {
        this.transform.Translate(Vector3.forward * (this.speed * Time.deltaTime));
    }

	// Update is called once per frame
	void Update ()
    {
        this.CheckForDamage();
        this.Move();
	}
}
