using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float follow_Height = 8f;
    public float follow_Distance = 6f;
    //public GameObject playerGO;

    private Transform player;

    private float target_Height;
    private float current_Height;
    private float current_Rotation;

    // Use this for initialization
    private void Awake()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        //this.player = this.playerGO.transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.target_Height = this.player.position.y + this.follow_Height;
        this.current_Rotation = this.transform.eulerAngles.y;
        this.current_Height = Mathf.Lerp(this.transform.position.y, this.target_Height, 0.9f * Time.deltaTime);
        Quaternion euler = Quaternion.Euler(0f, this.current_Rotation, 0f);
        Vector3 targetPosition = this.player.position - (euler * Vector3.forward) * this.follow_Distance;
        targetPosition.y = current_Height;
        this.transform.position = targetPosition;
        this.transform.LookAt(this.player);
	}
}
