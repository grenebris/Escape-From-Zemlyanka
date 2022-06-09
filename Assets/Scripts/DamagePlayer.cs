using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    protected bool damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = false;
    }

    // Update is called once per frame
    void Update()
    {
        DoDamage();
    }

    public void DoDamage()
    {

        if (damage)
        {
            Debug.Log("aboba_Damage");
            PlayerHealthController.instance.DamagePlayer();
            damage = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            damage = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            damage = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            damage = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            damage = true;
        }
    }
}
