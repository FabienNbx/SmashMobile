using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public FireBallMovement fireBall;

    private PlayerMovements playerMovements;
    private PlayerInput inputs;

    void Start()
    {
        playerMovements = GetComponent<PlayerMovements>();
        inputs = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if(inputs.attack)
        {
           attack();
        }
    }

    public void attack()
    {
        Vector3 sizePlayer = GetComponent<SpriteRenderer>().bounds.size; //Taille réelle du player
        Vector3 sizeMissile = fireBall.GetComponent<SpriteRenderer>().bounds.size; //Taille réelle d'une fireBall
        // Instancie un nouveau missile juste à côté du player en fonction de là où il regarde
        FireBallMovement missile = PhotonNetwork.Instantiate("NetworkPrefabs/FireBall", transform.position + new Vector3(playerMovements.look*(sizePlayer.x/2 + sizeMissile.x/2),0,0), transform.rotation).GetComponent<FireBallMovement>();
        Vector3 movement = new Vector3(playerMovements.look, 0, 0); //Indique la direction où on lance le missile
        missile.launch(movement); //Lance le missile
        missile.DestroyObjectDelayed();//Le missile est automatiquement détruit au bout d'un certain temps
    }
}
