using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public float nilaiBatasKanan;
    public float nilaiBatasKiri;
   
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!isLocalPlayer) return;

        float gerak = Input.GetAxis("Horizontal") * Time.deltaTime * 5f;
        
        float batasGerak = transform.position.x + gerak;

        if(batasGerak < nilaiBatasKiri)
        {
            gerak = 0;
        }

        if(batasGerak > nilaiBatasKanan)
        {
            gerak = 0;
        }
        transform.Translate(gerak, 0, 0);

    }
}
