using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunChest : MonoBehaviour
{
    public GameObject[] ChestGoods;
    public float itemDropPercent;

    public SpriteRenderer theSR;
    public Sprite chestOpen;

    public GameObject notification;

    private bool canOpen, isOpen;

    public Transform GunSpawnPoint;
    public Transform CoinSpawnPoint;
    public Transform HealthSpawnPoint;

    public float scaleSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canOpen && !isOpen)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                float dropChance;
                int RandCoinAmount;

                for (int i = 0; i < 3; i++)
                {
                    dropChance = Random.Range(0f, 100f);

                    if (dropChance < itemDropPercent)
                    {
                        if ((ChestGoods[i].GetComponent("Coin Pickup") as Pickups) != null)
                        {
                            RandCoinAmount = Random.Range(5, 10);
                            for (int j = 0; j < RandCoinAmount; j++)
                                Instantiate(ChestGoods[i], CoinSpawnPoint.position, CoinSpawnPoint.rotation);

                        }
                        if ((ChestGoods[i].GetComponent("GunPickup") as GunPickup) != null)
                            Instantiate(ChestGoods[i], GunSpawnPoint.position, GunSpawnPoint.rotation);

                        if ((ChestGoods[i].GetComponent("Health Pickup 1") as Pickups) != null)
                            Instantiate(ChestGoods[i], HealthSpawnPoint.position, HealthSpawnPoint.rotation);

                    }
                }


                theSR.sprite = chestOpen;

                isOpen = true;


                transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            }
        }

        if(isOpen)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.one, Time.deltaTime * scaleSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            notification.SetActive(true);

            canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            notification.SetActive(false);

            canOpen = false;
        }
    }
}
