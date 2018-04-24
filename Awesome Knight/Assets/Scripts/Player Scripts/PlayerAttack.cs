using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerAttack : MonoBehaviour
{
    public Image fillWaitImage_1;
    public Image fillWaitImage_2;
    public Image fillWaitImage_3;
    public Image fillWaitImage_4;
    public Image fillWaitImage_5;
    public Image fillWaitImage_6;

    private int[] fadeImages = new int[] { 0, 0, 0, 0, 0, 0 };
    private Animator anim;
    private bool canAttack = true;
    private PlayerMove playerMove;


    // Use this for initialization
    void Awake ()
    {
        this.anim = this.GetComponent<Animator>();
        this.playerMove = this.GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(!this.anim.IsInTransition(0) && this.anim.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
        {
            this.canAttack = true;
        }
        else
        {
            this.canAttack = false;
        }
	}
}
