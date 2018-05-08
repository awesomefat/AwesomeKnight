using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDamage : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float radius = 0.5f;
    public float damageCount = 10f;

    private EnemyHealth enemyHealthScript;
    private bool collided;

    // Update is called once per frame
    void Update ()
    {
        Collider[] hits = Physics.OverlapSphere(this.transform.position, this.radius, this.enemyLayer);
        foreach(Collider c in hits)
        {
            print("found collider");
            this.enemyHealthScript = c.gameObject.GetComponent<EnemyHealth>();
            this.collided = true;
        }

        if(this.collided)
        {
            this.enemyHealthScript.TakeDamage(this.damageCount);
            this.enabled = false;
        }
    }
}
