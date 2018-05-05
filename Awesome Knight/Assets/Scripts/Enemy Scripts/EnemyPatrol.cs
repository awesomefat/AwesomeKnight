using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] walkPoints;
    private NavMeshAgent navAgent;
    private Animator anim;
    private Transform player;
    private int currWalkPoint = 0;
    private bool shouldChase = false;

	// Use this for initialization
	void Awake ()
    {
        this.navAgent = this.GetComponent<NavMeshAgent>();
        this.anim = this.GetComponent<Animator>();
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
	}

    private void Start()
    {
        this.navAgent.SetDestination(this.walkPoints[this.currWalkPoint].position);
        this.anim.SetBool("Walk", true);
    }

    IEnumerator pauseThenMove()
    {
        yield return new WaitForSeconds(Random.Range(2,5));
        this.currWalkPoint = (this.currWalkPoint + 1) % this.walkPoints.Length;
        this.navAgent.enabled = true;
        this.navAgent.SetDestination(this.walkPoints[this.currWalkPoint].position);
        this.anim.SetBool("Walk", true);
    }

    // Update is called once per frame
    void Update ()
    {
        if(Vector3.Distance(this.transform.position, this.player.position) < 6f)
        {
            if(Vector3.Distance(this.transform.position, this.player.position) < 2.5f)
            {
                this.navAgent.isStopped = true;
                this.anim.SetBool("Walk", false);
                this.anim.SetBool("Run", false);
                this.anim.SetInteger("Atk", 1);
            }
            else
            {
                this.anim.SetBool("Walk", false);
                this.anim.SetBool("Run", true);
                this.navAgent.SetDestination(this.player.position);
            }
            this.shouldChase = true;
        }
        else
        {
            this.shouldChase = false;
            this.anim.SetBool("Run", false);
            this.anim.SetBool("Walk", true);
            this.navAgent.SetDestination(this.walkPoints[this.currWalkPoint].position);
        }
        
		if(!this.shouldChase && this.navAgent.isActiveAndEnabled && this.navAgent.remainingDistance < 0.3)
        {
            this.navAgent.isStopped = true;
            this.navAgent.enabled = false;
            this.anim.SetBool("Walk", false);
            this.transform.rotation = Quaternion.LookRotation(this.player.position - this.transform.position);
            this.StartCoroutine("pauseThenMove");
        }
	}
}
