using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {
    public GameObject laserObject;
    float timer;
    public float delayTime;
    public AudioClip shootLaserClip;
    private AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (!isLocalPlayer)
            return;


        //if (Input.GetKeyDown(KeyCode.Space))
        if (Input.GetButton("CustomFire"))
        {
            if (timer >= delayTime)
            {
                CmdSpawnLaser();
                timer = 0;
            }
            
        }
    }

    [Command]
    private void CmdSpawnLaser()
    {
        //Debug.Log("Laser Ditembakkan");
        audio.PlayOneShot(shootLaserClip);
        Vector3 offset = new Vector3(0, 0.5f, 0);
        GameObject laserSpawn = (GameObject)Instantiate(laserObject, transform.position + offset, Quaternion.identity);
        NetworkServer.Spawn(laserSpawn);
    }

}
