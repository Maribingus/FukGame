using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage;
    public ProjectileStats stats;

    // Start is called before the first frame update
    void Start()
    {
        damage = stats.damage;
        GetComponent<SpriteRenderer>().sprite = stats.sprite;
        GetComponent<Transform>().localScale = new Vector3(stats.sizeX, stats.sizeY, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {
            if (collision.GetComponent<Enemy>() != null)
            {
                collision.GetComponent<Enemy>().DealDamage(damage);
                print("mamabumsen");
            }
            //Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
