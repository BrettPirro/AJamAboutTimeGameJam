using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeJam.movements;
using TimeJam.Controls;
using TimeJam.Audio;


namespace TimeJam.AI 
{
    [RequireComponent(typeof(Movment))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class GhostAI : MonoBehaviour
    {
        Movment movmentScript;
        GameObject Player;
        [SerializeField]float Radius = 3f;
       [SerializeField] float speed = 3f;
        BoxCollider2D HitBox;
        bool notFound = false;
        [SerializeField] Vector3 offset;
        [SerializeField] GameObject JumpScareCanvas;
        public bool IsMoving;
        bool PlayClip = false;
        [SerializeField] AudioClip Laugh;
        [SerializeField] AudioClip JumpScare;
        bool done = false;
        void Start()
        {
            movmentScript = GetComponent<Movment>();
            HitBox = GetComponent<BoxCollider2D>();
            


            if (GameObject.FindGameObjectWithTag("Player") != null) 
            {
                Player=GameObject.FindGameObjectWithTag("Player") ;
               
            }
            else 
            {
                notFound = true;
            }

        }


        void FixedUpdate()
        {
            if (notFound) { return; }
            
            if(!(Vector2.Distance(Player.transform.position, transform.position) <= Radius)) { return;  }
            
            
            if (!HitBox.IsTouchingLayers(LayerMask.GetMask("FlashLight"))) 
            {
                movmentScript.UpdateMovmentBasedOnOBJPos(Player, speed*Time.fixedDeltaTime,offset);
                IsMoving = true;
                if (!PlayClip) 
                {
                    AudioCore.PlayClipAt(Laugh, Camera.main.transform.position, 0f, 1f);
                    PlayClip = true;
                }
            }
            else 
            {
                movmentScript.UpdateMovment(0, 0);
                IsMoving = false;
                PlayClip = false;
            }




           



        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player"&&!done) 
            {
                done = true;
                JumpScareCanvas.SetActive(true);
                Player.GetComponent<PlayerInput>().Die();
                AudioCore.PlayClipAt(JumpScare, Camera.main.transform.position, 0f, 1f);
            }
        }




    }
}
