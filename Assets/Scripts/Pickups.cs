using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public int coinValue = 1;
    public int healAmount = 1;

    public float waitToBeCollected = .5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitToBeCollected > 0)
        {
            waitToBeCollected -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && waitToBeCollected <= 0)
        {
            if(this.gameObject.name == "Health Pickup 1(Clone)")
                PlayerHealthController.instance.HealPlayer(healAmount);

            if (this.gameObject.name == "Coin Pickup(Clone)")
                LevelManager.instance.GetCoins(coinValue);

            Destroy(gameObject);

            AudioManager.instance.PlaySFX(5);
        }
    }
}
