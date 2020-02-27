using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth=100;  //santé de départ
    public int currentHealth;       //santé courante
    public Slider healthSlider;     //slider implémenté dans l'UI sur Unity
    public Image damageImage;       //image rouge qui flash sur l'écran
    public float flashSpeed= 5f;    //vitesse du flash
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);    //couleur de l'image rouge
    
    private Animator anim;          //appel au component Animator
    private PlayerMovements playerMovement;     //appel au script PlayerMovements
    private bool isDead;            //boolean mort
    private bool damaged;           //boolean pris des dégats

    void Start ()
    {
        anim = GetComponent <Animator> ();
        playerMovement = GetComponent <PlayerMovements> ();
        currentHealth = startingHealth;     //initialiser la santé à la santé de départ
    }

    void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;    //si damage pris, flasher un écran rouge
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime); //paramétrage du flash
        }
        damaged = false;
    }

    public void TakeDamage (int amount)
    {
        damaged = true;
        currentHealth -= amount;            //décrémenter la santé
        healthSlider.value = currentHealth; //ajuster la valeur du slider

        if(currentHealth <= 0 && !isDead)   //si santé atteint zéro et joueur pas déjà mort
        {
            Death ();                       //tuer le joueur
        }
    }

    void Death ()
    {
        isDead = true;                      //mettre le flag mort à 1
        anim.SetTrigger ("Die");            //animation de mort
        transform.position = new Vector2(0, 5);     //respawn
        currentHealth = startingHealth;     //réinitialiser la santé
    }


}