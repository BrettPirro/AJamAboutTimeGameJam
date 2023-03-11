using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeJam.Effects 
{
    [RequireComponent(typeof(Animator))]
    public class TutorialEffect : MonoBehaviour
    {
       
        
        Animator TutorialAnimator;
        [SerializeField] KeyCode InputChecked;
        

        void Start()
        {
            TutorialAnimator = GetComponent<Animator>();
        }


        void Update()
        {
            if (Input.GetKey(InputChecked)) 
            {
                TutorialAnimator.SetTrigger("Fade");

            }
        }
    
    
        public void Delete() 
        {
            Destroy(gameObject);
        }
    
    
    }

}