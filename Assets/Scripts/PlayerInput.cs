using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviourPun
{
    [HideInInspector]
    public int direction = 0; // = 1 pour droite, -1 pour gauche
    [HideInInspector]
    public bool jump;
    [HideInInspector]
    public bool attack;

    void Update()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected) return;
        direction = 0;
        direction += Input.GetKey(KeyCode.RightArrow)?1:0; //Si flèche de droite enfoncée, on va à droite (direction = 1)
        direction += Input.GetKey(KeyCode.LeftArrow) ? -1 : 0;  //Si flèche de gauche enfoncée, on va à gauche (direction = 1)
        jump = Input.GetKey(KeyCode.Space); //Si appuie sur espace, on saute
        attack = Input.GetKeyDown(KeyCode.J); //Si appuie sur j, on lance une attaque
    }
}
