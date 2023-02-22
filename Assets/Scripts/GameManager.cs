using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public GameObject cannon_body;
   public GameObject cannon_arm;
   public GameObject bomb;
   float bomb_speed;
   float rotation=100;
   bool is_powering_bomb=false;
   public GameObject enemy;
   int enemy_count=20;
   int bomb_count=30;
   float spacing=15 ;
   public Text text_bombs; 
   public Text text_enemies; 
    public Text text_result; 
    public float ClipLength=1f;
    public GameObject AudioClip;
   void Start()
    {
        //canon_arm initially set at the position of 45°
        cannon_arm.transform.Rotate(new Vector3(45,0,0));
        // Create enemies
        for(int i=0;i<enemy_count;i++){
            GameObject new_enemy=Instantiate(enemy);
            new_enemy.transform.position=new Vector3(Random.Range(-spacing,spacing), new_enemy.transform.position.y,Random.Range(-spacing,spacing));
        }
        text_bombs.text= bomb_count.ToString();
        text_enemies.text=enemy_count.ToString();
        AudioClip.SetActive(false);

    }
    void Update()
    {
        
         if(Input.GetKey(KeyCode.UpArrow)){
            cannon_arm.transform.Rotate(new Vector3(rotation*Time.deltaTime,0,0));
        }else{
             if(Input.GetKey(KeyCode.DownArrow)){
            cannon_arm.transform.Rotate(new Vector3(-rotation*Time.deltaTime,0,0));
        }}
        if(Input.GetKey(KeyCode.LeftArrow)){
            cannon_body.transform.Rotate(new Vector3(0,-rotation*Time.deltaTime,0));
        }else{
             if(Input.GetKey(KeyCode.RightArrow)){
            cannon_body.transform.Rotate(new Vector3(0,rotation*Time.deltaTime,0));
        }}
        if(Input.GetKeyDown(KeyCode.Space)){
            
bomb_speed=5;
is_powering_bomb=true; StartCoroutine(PlaySound());
        } 

        if(is_powering_bomb){
bomb_speed+=.1f;
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            is_powering_bomb=false;
            if(bomb_speed>50) bomb_speed=50;if(bomb_count>0){
            GameObject new_bomb=Instantiate(bomb);
            new_bomb.transform.position=cannon_arm.transform.position;
            new_bomb.GetComponent<Rigidbody>().velocity = cannon_arm.transform.up*bomb_speed;
            bomb_count--;
            text_bombs.text=bomb_count.ToString();}
            
        }
       
  
   
    }
    IEnumerator PlaySound(){
          AudioClip.SetActive(true);
          yield return new WaitForSeconds(ClipLength);
          AudioClip.SetActive(false);
            
        }
    
     public void DestroyEnemy(){
         enemy_count--;
    text_enemies.text=enemy_count.ToString();
    if( enemy_count==0){
         text_result.text="YOU WON";
    }
    } 
     public void CheckBullets(){
       
    if( bomb_count==0 && enemy_count>0){
         text_result.text="YOU LOST";
    }
    }
} 

