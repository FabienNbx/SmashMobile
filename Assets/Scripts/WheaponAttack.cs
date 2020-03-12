using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheaponAttack : MonoBehaviour
{
    private BoxCollider2D wheaponCollider;
    private PlayerAttack playerAttack;

    void Start()
    {
        playerAttack = transform.parent.GetComponent<PlayerAttack>();
        wheaponCollider = GetComponent<BoxCollider2D>();
        wheaponCollider.isTrigger = true; // Collisions désactivées par défaut
    }

    void Update()
    {
        if(playerAttack.isAttacking && wheaponCollider.isTrigger)
        {
            activateCollider();
        }
        if (!wheaponCollider.isTrigger && !playerAttack.isAttacking)
        {
            wheaponCollider.isTrigger = true; // Désactive les collisions sur l'arme
        }
    }

    private void activateCollider()
    {
        wheaponCollider.isTrigger = false; // Active les collisions sur l'arme
    }
}
