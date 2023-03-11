using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeJam.movements 
{

    [RequireComponent(typeof(Rigidbody2D))]

    public class Movment : MonoBehaviour
    {

        Rigidbody2D myrigidbody2D;
        Vector2 VelocityUpdate;
     

        private void Start()
        {
            myrigidbody2D = GetComponent<Rigidbody2D>();
          
        }

        public void UpdateMovmentBasedOnOBJPos(GameObject obj, float speed,Vector3 OBJOffset) 
        {
            myrigidbody2D.MovePosition(Vector2.MoveTowards(transform.position, obj.transform.position+OBJOffset,speed));
        }


        public void UpdateMovment(float x, float y) 
        {
            VelocityUpdate = new Vector2(x, y);
            myrigidbody2D.velocity = VelocityUpdate;

        }

        public float GetVelocityX() 
        {
            return myrigidbody2D.velocity.x;
        }

        public float GetVelocityY()
        {
            return myrigidbody2D.velocity.y;
        }

        public void UpdateDirection(float Update) 
        {
            if (Update==1 || Update==-1) 
            {
                transform.localScale= new Vector2( Update,transform.localScale.y);
            }
       
        }

        public float GetDirection() 
        {
            return transform.localScale.x;
        }


    }

}
