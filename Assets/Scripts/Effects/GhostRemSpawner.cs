using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeJam.AI;


[RequireComponent(typeof(GhostAI))]
public class GhostRemSpawner : MonoBehaviour
{
    [SerializeField] GameObject GhostHuskPrefab;
    [SerializeField] float TimeBetweenSpawns=0.8f;
    GhostAI ghostAI;
    float timer = Mathf.Infinity;

    private void Start()
    {
        ghostAI=GetComponent<GhostAI>();
    }

    private void Update()
    {
        if (ghostAI.IsMoving==true) 
        {
            if (timer >= TimeBetweenSpawns) 
            {
                Instantiate(GhostHuskPrefab, transform.position, transform.rotation);
                timer = 0;
            }

            timer += Time.deltaTime;
        }
      
    }



}
