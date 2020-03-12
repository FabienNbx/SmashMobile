using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public FireBallMovement fireBall;
    [HideInInspector]
    public Animator animator; //Gère les animations du player
    [HideInInspector]
    public bool isAttacking = false;


    private PlayerMovements playerMovements;
    private PlayerInput inputs;
    private int dir = 1; // Direction précédente, 1 pour droite et -1 pour gauche

    void Start()
    {
        playerMovements = GetComponent<PlayerMovements>();
        inputs = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (!isAttacking && inputs.direction == -1 && dir == 1) // Le player vient de tourner à gauche et n'est pas entrain d'attaquer
        {
            animator.SetTrigger("left");
            dir = -1;
        }
        if (!isAttacking && inputs.direction == 1 && dir == -1) // Le player vient de tourner à droite et n'est pas entrain d'attaquer
        {
            animator.SetTrigger("right");
            dir = 1;
        }
        if (inputs.distanceAttack)
        {
            distanceAttack();
        }
        else if(inputs.punchAttack)
        {
            punchAttack();
        }
        else if(inputs.uppercutAttack)
        {
            uppercutAttack();
        }
    }

    public void distanceAttack()
    {
        Vector3 sizePlayer = GetComponent<SpriteRenderer>().bounds.size; //Taille réelle du player
        Vector3 sizeMissile = fireBall.GetComponent<SpriteRenderer>().bounds.size; //Taille réelle d'une fireBall
        // Instancie un nouveau missile juste à côté du player en fonction de là où il regarde
        FireBallMovement missile = Instantiate(fireBall, transform.position + new Vector3(playerMovements.look*(sizePlayer.x/2 + sizeMissile.x/2),0,0), transform.rotation);
        Vector3 movement = new Vector3(playerMovements.look, 0, 0); //Indique la direction où on lance le missile
        missile.launch(movement); //Lance le missile
        missile.DestroyObjectDelayed();//Le missile est automatiquement détruit au bout d'un certain temps
    }

    public void punchAttack()
    {
        isAttacking = true;
        if (dir == 1) //on lance une attque à droite ou à gauche
            animator.SetTrigger("punch");
        else
            animator.SetTrigger("leftPunch");
    }

    public void uppercutAttack()
    {
        isAttacking = true;
        if (dir == 1) //on lance une attque à droite ou à gauche
            animator.SetTrigger("uppercut");
        else
            animator.SetTrigger("leftUppercut");
    }

    public void attackIsFinished() //appelée par un évenement de fin d'animation d'une attque dans l'animator controller
    {
        isAttacking = false;
    }
}
