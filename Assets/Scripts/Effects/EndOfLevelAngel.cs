using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeJam.Controls;
using TimeJam.SceneManage;

namespace TimeJam.Effects 
{
    [RequireComponent(typeof(Animator))]
    public class EndOfLevelAngel : MonoBehaviour
    {
        bool Done = false;
        Animator AngelAnimator;


        void Start()
        {
            AngelAnimator = GetComponent<Animator>();
        }

        public void AnimationOverForAngel()
        {
            FindObjectOfType<SceneManagers>().LoadNextScenes();
        }



        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player" && !Done)
            {

                AngelAnimator.SetTrigger("intro");
                Done = true;
                PlayerInput playerInput = collision.GetComponent<PlayerInput>();

                playerInput.DisableMovment = true;
                playerInput.AnimatorReset();

            }
        }




    }

}