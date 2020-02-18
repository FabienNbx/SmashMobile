using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("DeathZone"))
        {
            transform.position = new Vector2(0, 5);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
