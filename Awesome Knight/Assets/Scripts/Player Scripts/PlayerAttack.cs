using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerAttack : MonoBehaviour
{
    public Image[] theFillImages;

    private int[] fadeImages = new int[] { 0, 0, 0, 0, 0, 0 };
    public float[] fadeTimes = new float[] { 1.0f, 0.7f, 0.1f, 0.2f, 0.3f, 0.08f };
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

        this.CheckToFade();
        this.CheckInput();
	}

    

    void CheckInput()
    {
        if(this.anim.GetInteger("Atk") == 0)
        {
            this.playerMove.FinishedMovement = false;
            if (!this.anim.IsInTransition(0) && this.anim.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
            {
                this.playerMove.FinishedMovement = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.playerMove.Target_Pos = this.transform.position;
            if(this.playerMove.FinishedMovement && this.fadeImages[0] != 1 && this.canAttack)
            {
                this.fadeImages[0] = 1;
                this.anim.SetInteger("Atk", 1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.playerMove.Target_Pos = this.transform.position;
            if (this.playerMove.FinishedMovement && this.fadeImages[1] != 1 && this.canAttack)
            {
                this.fadeImages[1] = 1;
                this.anim.SetInteger("Atk", 2);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            this.playerMove.Target_Pos = this.transform.position;
            if (this.playerMove.FinishedMovement && this.fadeImages[2] != 1 && this.canAttack)
            {
                this.fadeImages[2] = 1;
                this.anim.SetInteger("Atk", 3);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            this.playerMove.Target_Pos = this.transform.position;
            if (this.playerMove.FinishedMovement && this.fadeImages[3] != 1 && this.canAttack)
            {
                this.fadeImages[3] = 1;
                this.anim.SetInteger("Atk", 4);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            this.playerMove.Target_Pos = this.transform.position;
            if (this.playerMove.FinishedMovement && this.fadeImages[4] != 1 && this.canAttack)
            {
                this.fadeImages[4] = 1;
                this.anim.SetInteger("Atk", 5);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            this.playerMove.Target_Pos = this.transform.position;
            if (this.playerMove.FinishedMovement && this.fadeImages[5] != 1 && this.canAttack)
            {
                this.fadeImages[5] = 1;
                this.anim.SetInteger("Atk", 6);
            }
        }
        else
        {
            this.anim.SetInteger("Atk", 0);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            Vector3 targetPos = Vector3.zero;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                targetPos = new Vector3(hit.point.x, this.transform.position.y, hit.point.z);
            }

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
                Quaternion.LookRotation(targetPos - this.transform.position), 
                15f * Time.deltaTime);
        }
    }

    void CheckToFade()
    {
        for(int i = 0; i < this.theFillImages.Length; i++)
        {
            if(this.fadeImages[i] == 1)
            {
                if(this.FadeAndWait(this.theFillImages[i], this.fadeTimes[i]))
                {
                    this.fadeImages[i] = 0;
                }
            }
        }
    }

    bool FadeAndWait(Image fadeImage, float fadeTime)
    {
        bool faded = false;

        if(fadeImage == null)
        {
            return faded;
        }
        
        if(!fadeImage.gameObject.activeInHierarchy)
        {
            fadeImage.gameObject.SetActive(true);
            fadeImage.fillAmount = 1.0f;
        }
        fadeImage.fillAmount -= fadeTime * Time.deltaTime;
        if(fadeImage.fillAmount <= 0.0f)
        {
            fadeImage.gameObject.SetActive(false);
            faded = true;
        }
        return faded;
    }
}










