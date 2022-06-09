using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBug : DamagePlayer
{
    //[SerializeField] protected float rangeToChasePlayer;

    [SerializeField] protected Rigidbody2D theRB;
    [SerializeField] protected float moveSpeed;
    protected Vector3 moveDirection;

    [SerializeField] protected SpriteRenderer theBody;
    [SerializeField] protected Animator anim;

    [SerializeField] protected int health = 150;

    [SerializeField] protected GameObject[] deathSplatters;
    [SerializeField] protected GameObject hitEffect;

    [SerializeField] protected GameObject[] itemsToDrop;
    [SerializeField] protected float itemDropPercent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DoDamage();
        Chase();
    }

    public void Chase()
    {
        if (theBody.isVisible && PlayerController.instance.gameObject.activeInHierarchy)
        {
            moveDirection = Vector3.zero;

            //if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToChasePlayer)
            //{
                moveDirection = PlayerController.instance.transform.position - transform.position;
            //}
        }

        moveDirection.Normalize();

        theRB.velocity = moveDirection * moveSpeed;
        
        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    public void DamageEnemy(int damage)
    {
        health -= damage;

        AudioManager.instance.PlaySFX(2);

        Instantiate(hitEffect, transform.position, transform.rotation);

        if (health <= 0)
        {
            Destroy(gameObject);

            AudioManager.instance.PlaySFX(1);

            int selectedSplatter = Random.Range(0, deathSplatters.Length);

            int rotation = Random.Range(0, 4);

            Instantiate(deathSplatters[selectedSplatter], transform.position, Quaternion.Euler(0f, 0f, rotation * 90f));

            float dropChance = Random.Range(0f, 100f);

            if (dropChance < itemDropPercent)
            {
                int randomItem = Random.Range(0, itemsToDrop.Length);

                Instantiate(itemsToDrop[randomItem], transform.position, transform.rotation);
            }
        }
    }

}
