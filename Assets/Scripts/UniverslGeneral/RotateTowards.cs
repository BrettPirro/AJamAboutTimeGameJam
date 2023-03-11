using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TimeJam.UniversalGeneral 
{
    public class RotateTowards : MonoBehaviour
    {
        [SerializeField] bool RotateToMouse = false;
        [SerializeField] Transform RotatePoint;
        Vector3 dir;
        [SerializeField]float offset=0f;
        [SerializeField]bool disablerestrain=false;
        [SerializeField] float AngleRestrainMin;
        [SerializeField] float AngleRestrainMax;

        bool RotateEnabled = true;

        private void Update()
        {
            if (!RotateEnabled) { return; }
            
            
            
            if (RotateToMouse)
            {
                dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

            }
            else
            {
                dir = Camera.main.WorldToScreenPoint(RotatePoint.position) - Camera.main.WorldToScreenPoint(transform.position);

            }
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + offset;

            AngleUpdate(angle);

        }

        public void AngleUpdate(float angle)
        {
            if (disablerestrain&&( angle  >= AngleRestrainMax || angle  <= AngleRestrainMin )){return;}
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }


        public void UpdateOffset(float UpdateVar) 
        {
            offset = UpdateVar;
        }


        public void EnableOrDisableRotate(bool UpdateBool ) 
        {
            RotateEnabled = UpdateBool;
        }
      
    }






    }

    







