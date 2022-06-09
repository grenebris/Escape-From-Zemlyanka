using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnt : EnemyBug
{
  
    [Header("Shooting")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate;
    private float fireCounter;

    public float shootRange;

    // Start is called before the first frame update
    void Start()
    {
        //theRB = this.gameObject.GetComponent<Rigidbody2D>();
        //moveSpeed = 3f;
        //theBody = this.GetComponent<SpriteRenderer>();
        //anim = this.GetComponent<Animator>();
        //health = 200;
        //deathSplatters = new GameObject[4];
        //deathSplatters[0] = Resources.Load("Splatter_0") as GameObject;
        //deathSplatters[1] = Resources.Load("Splatter_1") as GameObject;
        //deathSplatters[2] = Resources.Load("Splatter_2") as GameObject;
        //deathSplatters[3] = Resources.Load("Splatter_3") as GameObject;
        //hitEffect = Resources.Load("Enemy Hit Effect") as GameObject;
        //itemsToDrop = new GameObject[1];
        //itemsToDrop[0] = Resources.Load("Coin Pickup") as GameObject;
        //itemsToDrop[1] = Resources.Load("Health Pickup 1") as GameObject;
        //itemDropPercent = 50f;
        //bullet = Resources.Load("Enemy Bullet") as GameObject;
        //firePoint = this.gameObject.transform.Find("Firepoint") as Transform;
        //fireRate = 1f;
        //fireCounter = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
        DoDamage();
        Shoot();
    }

    public void Shoot()
    {
        if (theBody.isVisible && PlayerController.instance.gameObject.activeInHierarchy) {
            fireCounter -= Time.deltaTime;

        if (fireCounter <= 0)
            {
                fireCounter = fireRate;
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                AudioManager.instance.PlaySFX(13);
            }
        }
    }

}
