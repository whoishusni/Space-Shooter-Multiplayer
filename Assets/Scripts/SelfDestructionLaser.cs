﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructionLaser : MonoBehaviour {

    float timer = 0;
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= 2f)
        {
            Destroy(gameObject);
        }
	}
}
