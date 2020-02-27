using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) //Si le player tombe de la map, il réapparait
    {
        if(collision.gameObject.CompareTag("DeathZone"))
        {
            transform.position = new Vector2(0, 5);
        }
    }

}
