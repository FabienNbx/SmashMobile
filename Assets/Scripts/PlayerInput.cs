using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector]
    public int direction; // = 1 pour droite, -1 pour gauche
    [HideInInspector]
    public bool jump;
    [HideInInspector]
    public bool distanceAttack;
    [HideInInspector]
    public bool punchAttack;
    [HideInInspector]
    public bool uppercutAttack;

    void Update()
    {
        direction = 0;
        direction += Input.GetKey(KeyCode.RightArrow)?1:0; //Si flèche de droite enfoncée, on va à droite (direction = 1)
        direction += Input.GetKey(KeyCode.LeftArrow) ? -1 : 0;  //Si flèche de gauche enfoncée, on va à gauche (direction = 1)
        jump = Input.GetKey(KeyCode.Space); //Si appuie sur espace, on saute
        distanceAttack = Input.GetKeyDown(KeyCode.J); //Si appuie sur j, on lance une attaque à distance
        punchAttack = Input.GetKeyDown(KeyCode.K); //Si appuie sur k, on lance une attaque "coup de point"
        uppercutAttack = Input.GetKeyDown(KeyCode.L); //Si appuie sur l, on lance une attaque "uppercut"
    }
}
