using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeJam.movements;
using TimeJam.UniversalGeneral;
using TimeJam.SceneManage;

namespace TimeJam.Controls 
{
    [RequireComponent(typeof(Movment))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(FlashLightToggle))]
    [RequireComponent(typeof(Animator))]
    public class PlayerInput : MonoBehaviour
    {
        #region Vars
        //Script Refrences 
        Movment movmentScript;
        Vector2 MovmentUpdate;
        BoxCollider2D GroundCheck;
        FlashLightToggle flashLightToggleScript;
        Animator MyAnimator;
        [SerializeField]BoxCollider2D UnCrouchCheck;

        //General Movment Vars
        [SerializeField] float speed = 5f;
        [SerializeField] float JumpHeight = 12f;

        //Movment Keys
        [SerializeField] KeyCode DashBtn;
        [SerializeField] KeyCode ToggleFlashBtn;

        //Dash Settings
        [SerializeField] [Range(0f, 1f)] float SlideCoolDown = .3f;
        float SlideTimer = Mathf.Infinity;
        bool Slided = false;
        [SerializeField] float SlidePower = 7f;
        bool SlideDustSpawned = false;


        //Coyote Time Vars
        bool CoyoteTimeBool = false;
        float CoyoteTimeTimer = Mathf.Infinity;
        [SerializeField] [Range(0f, 1f)] float CoyoteTimeLimit = .2f;

        //Jump Vars
        bool Jumped = false;

        //Flashlight
        [SerializeField] RotateTowards Flashrotate;

        //Prefabs
        [SerializeField] GameObject Dust;

        //Transforms
        [SerializeField] Transform DustSpawnPoint;
        [SerializeField] Transform DustStorage;

        List<float> IndexofKeysPickedUp=new List<float>();


        bool Dies = false;
        bool WakeUp = true;
        bool fall=false;
        public bool DisableMovment=false;
        #endregion

        void Start()
        {
            
         
           GroundCheck = GetComponent<BoxCollider2D>();
            movmentScript = GetComponent<Movment>();
            flashLightToggleScript = GetComponent<FlashLightToggle>();
            MyAnimator = GetComponent<Animator>();

            Flashrotate.EnableOrDisableRotate(false);

        }

        private void FixedUpdate()
        {
            DeathCheck();
            if (Dies) { return; }
            if (DisableMovment) { return; }

            if (WakeUp) { return; }

            MovmentUpdateFunc();



        }

        private void Update()
        {
            if (Dies) { return; }
            if (DisableMovment) { return; }

            if (movmentScript.GetVelocityY() <= -30 && !WakeUp)
            {

                MyAnimator.SetTrigger("Fall");


                WakeUp = true;
                fall = true;
            }
            else if (fall && GroundCheck.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                MyAnimator.SetBool("FallComplete", true);
                movmentScript.UpdateMovment(0f, 0f);
                fall = false;
            }


            if (WakeUp) { return; }
            CoyoteTimeDetermination();
            FlashLightInput();
        }


        public void EndFallAnimation() 
        {
            MyAnimator.SetBool("FallComplete", false);
            WakeUpDone();
        }


        private void DeathCheck()
        {
            if (GroundCheck.IsTouchingLayers(LayerMask.GetMask("WaterLayer")) && !Dies)
            {
                Die();
            }
        }

        public void Die() 
        {
            Dies = true;
            movmentScript.UpdateMovment(0f, movmentScript.GetVelocityY());
            Flashrotate.EnableOrDisableRotate(false );
            MyAnimator.SetBool("Death", Dies);
            if (flashLightToggleScript.GetFlashToggleVal()) 
            {
                flashLightToggleScript.ToggleFlashLight(!flashLightToggleScript.GetFlashToggleVal());
            }

        }

        void MoveToGameOver() 
        {
            FindObjectOfType<SceneManagers>().LoadGameOvers();
        }

        public void WakeUpStart() 
        {
            if (flashLightToggleScript.GetFlashToggleVal()) { flashLightToggleScript.ToggleFlashLight(!flashLightToggleScript.GetFlashToggleVal()); }
            Flashrotate.EnableOrDisableRotate(false);
            WakeUp = true;
        }
        
        
        public void WakeUpDone() 
        {
            Flashrotate.EnableOrDisableRotate(true);
            AnimatorReset();
            WakeUp = false;
        }


        #region MovmentFunctions

        private void MovmentUpdateFunc()
        {
            MyAnimator.SetBool("SlideComplete", Slided);
          
            GeneralMovment();
           
            Jump();
            Slide();
            FlashRotate();
         
            movmentScript.UpdateMovment(MovmentUpdate.x, MovmentUpdate.y);
        }

        private void FlashLightInput()
        {
            if (Input.GetKeyDown(ToggleFlashBtn))
            {
                flashLightToggleScript.ToggleFlashLight(!flashLightToggleScript.GetFlashToggleVal());
            }
        }

        public void AnimatorReset() 
        {
            MyAnimator.SetBool("Walking", false);
            MyAnimator.SetBool("OnGround", true);
            MyAnimator.SetBool("SlideComplete", false);
        }

        private void FlashRotate()
        {
            if (Flashrotate != null)
            {
                if (movmentScript.GetDirection()<0)
                {
                    Flashrotate.UpdateOffset(180f);
                }
                else if(movmentScript.GetDirection() > 0)
                {
                    Flashrotate.UpdateOffset(0);
                }


            }
        }

        private void GeneralMovment()
        {
            if (Slided) { return; }
            if (Input.GetAxis("Horizontal") != 0)
            {
               
                MovmentUpdate = new Vector2(Input.GetAxisRaw("Horizontal") * speed, movmentScript.GetVelocityY());
                movmentScript.UpdateDirection(Input.GetAxisRaw("Horizontal"));
                MyAnimator.SetBool("Walking", true);
             
            }
            else 
            {

                MovmentUpdate = new Vector2(0, movmentScript.GetVelocityY());
                MyAnimator.SetBool("Walking", false);
            }
        }

        private void Jump()
        {
            if (Slided) { return; }

            if (CoyoteTimeBool && !Jumped)
            {
                Jumped = true;
                MyAnimator.SetTrigger("Jump");
                MovmentUpdate = new Vector2(movmentScript.GetVelocityX(), JumpHeight);
                
                CoyoteTimeTimer = 0f;
                Debug.Log("Jumped");
            }
            
            

        }


        private void CoyoteTimeDetermination()
        {
            

            if (Input.GetKey(KeyCode.Space)&& CoyoteTimeTimer <= CoyoteTimeLimit )
            {
               
                CoyoteTimeBool = true;
                
                
               
               
            }
            else 
            {
                CoyoteTimeBool = false;
               


            }

            CoyoteTimerActivation();

        }

        private void CoyoteTimerActivation()
        {
            if (!GroundCheck.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                CoyoteTimeTimer += Time.deltaTime;
                
             
                MyAnimator.SetBool("OnGround", false);

            }
            else if (GroundCheck.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                
                CoyoteTimeTimer = 0f;
                MyAnimator.SetBool("OnGround", true);
                Jumped = false;

            }

           


        }

        private void Slide() 
        {
            if (Slided)
            {

                MovmentUpdate = Vector2.Lerp(new Vector2(movmentScript.GetVelocityX(), movmentScript.GetVelocityY()), new Vector2(0.3f*Input.GetAxisRaw("Horizontal"), movmentScript.GetVelocityY()), Time.deltaTime);
                if (Mathf.Round(MovmentUpdate.x) != 0 && !SlideDustSpawned)
                {

                    StartCoroutine(DustSpawn());
                    SlideDustSpawned = true;
                }


                SlideTimer += Time.deltaTime;
            }







            if (Input.GetKey(DashBtn) && SlideTimer <= SlideCoolDown && GroundCheck.IsTouchingLayers(LayerMask.GetMask("Ground"))&&!Slided&&Input.GetAxisRaw("Horizontal")!=0) 
            {
                Debug.Log("Dashed");
                Slided = true;
                MyAnimator.SetTrigger("Slide");
                StartCoroutine(SlideForward());
            }
            
            
            else if ((SlideTimer >= SlideCoolDown&& !(Input.GetKey(DashBtn))))
            {
                if (!Physics2D.IsTouchingLayers(UnCrouchCheck,LayerMask.GetMask("Ground")))
                {
                    Slided = false;
                    SlideTimer = 0;
                    SlideDustSpawned = false;
                    StopAllCoroutines();
                }
                else 
                {
                    Slided = true;
                 
                }


               
            }

           
            
           


        }


        IEnumerator SlideForward() 
        {
            for (int i = 0; i <= 3; i++)
            {
                MovmentUpdate = new Vector2(SlidePower * Input.GetAxisRaw("Horizontal"), movmentScript.GetVelocityY());
                yield return new WaitForSeconds(.01f);
                Debug.Log("Slided");
            }

         

        }

        IEnumerator DustSpawn() 
        {
            GameObject DustOBJ= Instantiate(Dust, DustSpawnPoint.position, DustSpawnPoint.rotation,DustStorage) as GameObject;
            yield return new WaitForSeconds(.2f);
            SlideDustSpawned = false;
        }

        #endregion

        public bool CheckForKeyIndex(float check) 
        {
            if (IndexofKeysPickedUp == null) { return false; }
            
            foreach(float i in IndexofKeysPickedUp) 
            {
                if (check == i) 
                {
                    return true;
                }
            }

            return false;
        }

        public void UpdateKeyIndex(float update) 
        {
            IndexofKeysPickedUp.Add(update);
        }


    }

}