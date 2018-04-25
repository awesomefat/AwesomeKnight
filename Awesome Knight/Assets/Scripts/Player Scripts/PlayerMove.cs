using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator anim;
    private CharacterController charController;
    private CollisionFlags collisionFlags;

    private float moveSpeed = 5f;
    private bool canMove;
    private bool finishedMovement = true;

    private Vector3 target_Pos = Vector3.zero;
    private Vector3 player_Move = Vector3.zero;

    private float player_ToPointDistance;
    private float gravity = 9.8f;
    private float height;

    public bool FinishedMovement
    {
        get
        {
            return finishedMovement;
        }

        set
        {
            finishedMovement = value;
        }
    }

    public Vector3 Target_Pos
    {
        get
        {
            return target_Pos;
        }

        set
        {
            target_Pos = value;
        }
    }

    // Use this for initialization
    void Awake()
    {
        this.anim = this.GetComponent<Animator>();
        this.charController = this.GetComponent<CharacterController>();
        this.collisionFlags = this.charController.collisionFlags;
    }

    void MoveThePlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider is TerrainCollider)
                {
                    this.player_ToPointDistance = Vector3.Distance(this.transform.position, hit.point);
                    if (this.player_ToPointDistance >= 1.0f)
                    {
                        this.Target_Pos = hit.point;
                        this.canMove = true;
                    }
                }
            }
        }

        if (this.canMove)
        {
            this.anim.SetFloat("Walk", 1.0f);
            Vector3 targetTemp = new Vector3(this.Target_Pos.x, this.transform.position.y, this.Target_Pos.z);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(targetTemp - this.transform.position), 15f * Time.deltaTime);
            this.player_Move = this.transform.forward * this.moveSpeed * Time.deltaTime;

            if (Vector3.Distance(Target_Pos, this.transform.position) <= 0.5f)
            {
                this.canMove = false;
            }
        }
        else
        {
            this.player_Move.Set(0f, 0f, 0f);
            this.anim.SetFloat("Walk", 0f);
        }

    }

    bool IsGrounded()
    {
        return this.collisionFlags == CollisionFlags.Below ? true : false;
    }

    void CalculateHeight()
    {
        if(this.IsGrounded())
        {
            this.height = 0f;
        }
        else
        {
            this.height -= this.gravity * Time.deltaTime;
        }
    }

    void CheckIfFinishedMovement()
    {
        if (!this.FinishedMovement)
        {
            if (!this.anim.IsInTransition(0) && !this.anim.GetCurrentAnimatorStateInfo(0).IsName("Stand") &&
                this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                this.FinishedMovement = true;
            }
        }
        else
        {
            this.MoveThePlayer();
            this.player_Move.y = this.height * Time.deltaTime;
            this.collisionFlags = this.charController.Move(this.player_Move);
        }
    }

	// Update is called once per frame
	void Update ()
    {
        this.CalculateHeight();
        this.CheckIfFinishedMovement();
	}

   

}
