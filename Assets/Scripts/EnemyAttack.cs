using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;

public class EnemyAttack : NetworkBehaviour {
    public int health;
    public float speed;
    public AudioClip explosionClip;
    private AudioSource audioSource;
   
  

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    private void Update()
    {
       // Debug.Log("Musuh bergerak");
        Vector3 position = transform.position;
        position.y -= speed * Time.deltaTime;
        transform.position = position;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            health--;
            if (health <= 0)
            {
                audioSource.PlayOneShot(explosionClip);
                //Debug.Log("Pesawat Musuh Hancur");
                NetworkServer.Destroy(gameObject);
            }
        }

        //RENCANA SAYA MAU SIMPAN METHOD KE SCRIPT BARU
        if(collision.gameObject.name == "gameOverCollider")
        {
            RpcGameOver();
        }

    }

    [ClientRpc]
    private void RpcGameOver()
    {
        //Debug.Log("Method RpcGameOver dipanggil");
        SceneManager.LoadScene("GameOver");
       
    }
}
