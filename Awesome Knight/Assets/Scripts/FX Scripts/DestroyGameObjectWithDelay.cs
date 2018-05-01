﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjectWithDelay : MonoBehaviour
{
    public float timeToWait = 2f;

	// Use this for initialization
	void Start ()
    {
        Destroy(this.gameObject, this.timeToWait);
	}
}
