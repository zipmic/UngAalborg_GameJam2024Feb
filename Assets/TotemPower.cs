using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class TotemPower : MonoBehaviour
{
    public float totemCheckRadius = 5f;
    public float checkInterval = 1f;
    public int amountOfChecks = 10;
    public LayerMask checkLayerMask;
    public GameObject SpawnWhenDestroyed;

    public TextMeshProUGUI _totemcounter;

    public float DMGAdd = 1;

    private void Start()
    {
        _totemcounter.text = amountOfChecks.ToString() ;
        StartCoroutine(CheckForPlayersAndEnemies());
    }

    private IEnumerator CheckForPlayersAndEnemies()
    {
        for (int i = 0; i < amountOfChecks; i++)
        {
            _totemcounter.text = (amountOfChecks - i).ToString();
            yield return new WaitForSeconds(checkInterval); // Wait for the checkInterval before checking again
            print("Check around totem");
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, totemCheckRadius, checkLayerMask);
            foreach (Collider2D collider in hitColliders)
            {

                Health health = collider.GetComponent<Health>();
                if (health != null)
                {
                    if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Enemy"))
                    {
                        if (i == amountOfChecks - 1)
                        {
                            health.UnleashStackedDamage();
                            gameObject.SetActive(false);

                        }
                        else
                        {
                            health.stackDamage(DMGAdd);
                        }
                    }
                }
            }
            if (i == amountOfChecks - 1)
            {
                GameObject spawn = Instantiate(SpawnWhenDestroyed) as GameObject;
                spawn.transform.position = transform.position;

            }
        }
    }




}
