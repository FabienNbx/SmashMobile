using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMovement : MonoBehaviour
{
    public int speed;

    private bool move = false;
    private Vector3 direction;
    private int timeDestruction = 3;
    public void launch(Vector3 dir)
    {
        move = true;
        direction = dir;
    }

    private void FixedUpdate()
    {
        if (!move) return;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void DestroyObjectDelayed()
    {
        Destroy(gameObject, timeDestruction); //Detruit l'objet après un certain temps passé en paramètre
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("ennemi"))
        {
            Destroy(gameObject);
        }
    }

}
