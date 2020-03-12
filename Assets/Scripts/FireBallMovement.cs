using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMovement : MonoBehaviourPun
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
        if (!photonView.IsMine && PhotonNetwork.IsConnected) return;
        StartCoroutine(WaitBeforeDestroy()); //Detruit l'objet après un certain temps passé en paramètre
    }

    private IEnumerator WaitBeforeDestroy ()
    {
        yield return new WaitForSeconds(timeDestruction);
        PhotonNetwork.Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected) return;
        if (other.gameObject.CompareTag("ennemi") || other.gameObject.CompareTag("Terrain"))
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }

}
