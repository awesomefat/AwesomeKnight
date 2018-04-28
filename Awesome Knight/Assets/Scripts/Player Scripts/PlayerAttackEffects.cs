using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEffects : MonoBehaviour
{
    public GameObject groundImpact_Spawn, kickFX_Spawn, fireTornado_Spawn, fireShield_Spawn;
    public GameObject groundImpact_Prefab, kickFX_Prefab, fireTornado_Prefab, fireShield_Prefab, 
        heal_Prefab, thunder_Prefab;


	// Update is called once per frame
	void Update () {
		
	}

    void GroundImpact()
    {
       GameObject obj = Instantiate(groundImpact_Prefab, groundImpact_Spawn.transform.position, Quaternion.identity) as GameObject;
    }

    void Kick()
    {
        GameObject obj = Instantiate(kickFX_Prefab, kickFX_Spawn.transform.position, Quaternion.identity) as GameObject;
    }

    void FireTornado()
    {
        GameObject obj = Instantiate(fireTornado_Prefab, fireTornado_Spawn.transform.position, Quaternion.identity) as GameObject;
    }

    void FireShield()
    {
        GameObject obj = Instantiate(fireShield_Prefab, fireShield_Spawn.transform.position, Quaternion.identity) as GameObject;
        obj.transform.SetParent(this.transform);
    }

    void ThunderAttack()
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        float z = this.transform.position.z;
        float[] xs = {x-4f, x+4f, x,x, x+2.5f, x-2.5f, x-2.5f, x+2.5f};
        float[] ys = {y+2f, y + 2f, y + 2f, y + 2f, y + 2f, y + 2f, y + 2f, y + 2f};
        float[] zs = {z,z,z-4f, z+4f, z+2.5f, z + 2.5f, z - 2.5f, z + 2.5f};
        for(int i = 0; i < 8; i++)
        {
            Instantiate(this.thunder_Prefab, new Vector3(xs[i], ys[i], zs[i]), Quaternion.identity);
        }
    }

    void Heal()
    {
        Vector3 temp = this.transform.position;
        temp.y += 2f;
        GameObject obj = Instantiate(heal_Prefab, temp, Quaternion.identity) as GameObject;
        obj.transform.SetParent(this.transform);
    }
}





















