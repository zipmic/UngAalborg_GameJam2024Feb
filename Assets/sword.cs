using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    public float damage = 10;

    private float Cooldown = 1;




    private void OnTriggerStay2D(Collider2D collision)
    {
       

        if(collision.tag == "Player" && Cooldown < 0)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Cooldown = 1;
        }
    }

    void Update()
    {
        Cooldown -= Time.deltaTime;
    }
}
