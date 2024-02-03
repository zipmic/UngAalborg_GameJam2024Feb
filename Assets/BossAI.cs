using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float attackRange = 1f;
    public float rotationSpeed = 10f;
    public float slashDelay = 1f;

    private Health MyHealth;

    public GameObject Sword;

    private Rigidbody2D rb;
    public float swordPauseTime;
    private float swordpausecounter;
    private float StartSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MyHealth = GetComponent<Health>();
        StartSpeed = moveSpeed;
     
    }

    private void Update()
    {
        if(swordpaused)
        {
            swordpausecounter -= Time.deltaTime;
            if(swordpausecounter <= 0)
            {
                swordpaused = false;
            }
        }

        moveSpeed = StartSpeed * (1+(MyHealth.GetStackedDamage()/10));
    }
    private void FixedUpdate()
    {
        Vector2 direction = (Vector2)player.position - rb.position;
        float distance = direction.magnitude;

        if (distance > attackRange)
        {
            rb.MovePosition(rb.position + direction.normalized * moveSpeed * Time.fixedDeltaTime);
            float rotationAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = Mathf.LerpAngle(rb.rotation, rotationAngle, rotationSpeed * Time.fixedDeltaTime);
        }
        else
        {
            StartCoroutine(SlashRoutine());
        }
    }

    private IEnumerator SlashRoutine()
    {
        yield return new WaitForSeconds(slashDelay);
        Slash();
    }

    private IEnumerator DisableAfter(GameObject target)
    {
       
        yield return new WaitForSeconds(slashDelay);
        Sword.SetActive(false);
        swordpaused = true;
        swordpausecounter = swordPauseTime;

    }

    bool swordpaused = false;

    public void Slash()
    {
        if (!swordpaused)
        {
            // Implement slash attack here
            Sword.SetActive(true);
            StartCoroutine(DisableAfter(Sword));
        }
    }
}