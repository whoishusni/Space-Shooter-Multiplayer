using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Laser : NetworkBehaviour {

    float destructionTimer = 0;
    private void Update()
    {
        Vector3 direction = transform.position;
        direction.y += Time.deltaTime * 5f;
        transform.position = direction;

        destructionTimer += Time.deltaTime;
        if (destructionTimer >= 2f)
        {
            //Destroy(gameObject);
            NetworkServer.Destroy(gameObject);
        }
        
    }

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
            NetworkServer.Destroy(gameObject);
        }
       
        
    }

   




}
