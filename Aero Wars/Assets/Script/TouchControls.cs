﻿using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {


	public GameObject mainBullet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			Instantiate(mainBullet,transform.position+ new Vector3(0f,0f,0.5f),transform.rotation);
				}
	
	}
}
