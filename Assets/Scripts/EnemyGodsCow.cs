using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGodsCow : EnemyAnt
{
    [SerializeField] private float runawayRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RunAway();
        DoDamage();
        Shoot();
    }

    private void RunAway()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < runawayRange)
        {
            moveDirection = transform.position - PlayerController.instance.transform.position;
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
}
