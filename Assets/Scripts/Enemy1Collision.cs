using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Collision : MonoBehaviour
{
    public GameObject exp1;
    public GameObject exp2;
    public GameObject exp3;
    public int damage;
    public Enemy1Controller controller;
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.name == "Player")
        {
            // player should take damage here
            other.GetComponent<PlayerController>().TakeDamage(damage);
        }
        else
        {
            if (other.tag == "Weapon")
            {
                
                controller.health -= other.gameObject.GetComponent<Pencilshootbehaviour>().damage;
                Destroy(other.gameObject);
                if (controller.health <= 0)
                {
                    SpawnExp();
                    ScoreManager.instance.AddPoint();
                    Destroy(this.gameObject);
                }

            }
        }

    }

    private void SpawnExp(){
        int n = Random.Range(0,4);
        switch (n)
        {
            case 0:
            {
                GameObject e = Instantiate(exp1) as GameObject;
                e.transform.position = transform.position;
                break;
            }
            case 1:
            case 2:
            {
                GameObject e = Instantiate(exp2) as GameObject;
                e.transform.position = transform.position;
                break;
            }
            case 3:
            {   
                GameObject e = Instantiate(exp3) as GameObject;
                e.transform.position = transform.position;
                break;
            }
            
        }
    }
}
