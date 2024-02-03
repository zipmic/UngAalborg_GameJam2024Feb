using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Health : MonoBehaviour
{

    public Image HealthImage;

    public float health = 100;
    private float maxhealth;
    public TextMeshProUGUI StackedDMG;
    public bool isEnemy;


    private float stackedDamage = 0;
    // Start is called before the first frame update
    void Start()
    {
        maxhealth = health;
    }

    public float GetStackedDamage()
    {
        return stackedDamage;
    }

    // Update is called once per frame
    void Update()
    {
        HealthImage.fillAmount = health / maxhealth;
        StackedDMG.text = stackedDamage.ToString();
    }

    public void stackDamage(float dmg)
    {
        stackedDamage += dmg;
        print("Added " + dmg + " to " + name);
    }

    public void UnleashStackedDamage()
    {
        TakeDamage(stackedDamage);
        print(name + " took " + stackedDamage + " of stacked damage");
        ClearStackedDamage();
    }

    public void ClearStackedDamage()
    {
        stackedDamage = 0;
        print(name + " had stackDMG cleared");
    }

    public void Die()
    {

    }

    public GameObject Win, Lose;

    public void TakeDamage(float damage)
    {
        health -= damage;
        print(name+" took "+damage+" dmg");
        if(health <= 0)
        {
            if(isEnemy)
            {
                Win.SetActive(true);
            }
            else
            {
                Lose.SetActive(true);

            }
        }
    }
}
