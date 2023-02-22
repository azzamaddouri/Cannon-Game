using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{ 
    public ParticleSystem explosion;
    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager=FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.collider.CompareTag("Enemy")){
     Destroy(collision.collider.gameObject);
       manager.DestroyEnemy();
        }
        ParticleSystem new_explosion = Instantiate(explosion);
        new_explosion.transform.position=transform.position;
        new_explosion.Play();
        //Destroy the explosion
        Destroy(new_explosion.gameObject,2);
        manager.CheckBullets();
         //Destroy the bomb
        Destroy(gameObject);

    }
}
