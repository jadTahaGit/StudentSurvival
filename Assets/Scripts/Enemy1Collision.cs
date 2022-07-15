using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Collision : MonoBehaviour
{
    public GameObject exp1;
    public GameObject exp2;
    public GameObject exp3;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "Player"){
            // player should take damage here
        }
        else{
            if(other.tag == "Weapon"){
                ScoreManager.instance.AddPoint();
                SpawnExp();
                Destroy(this.gameObject);

            
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
