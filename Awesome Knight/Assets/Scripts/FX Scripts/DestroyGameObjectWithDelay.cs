using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjectWithDelay : MonoBehaviour
{
    public float timeToWait = 0.1f;

    IEnumerator killMyself()
    {
        yield return new WaitForSeconds(this.timeToWait);
        Destroy(this.gameObject);
    }

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(killMyself());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
