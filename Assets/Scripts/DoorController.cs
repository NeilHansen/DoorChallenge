﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public int machineCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(machineCount <=0)
        {
            this.transform.position = new Vector3(this.transform.position.x, -2.46f, this.transform.position.z);
        }
	}
}
