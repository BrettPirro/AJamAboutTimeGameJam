using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeJam.Controls;

namespace TimeJam.Effects 
{
    public class Key : MonoBehaviour
    {
        [SerializeField] float index;
        [SerializeField] GameObject ParticlesSpawn;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerInput>().UpdateKeyIndex(index);
                Instantiate(ParticlesSpawn, transform.position,transform.rotation);
                Destroy(gameObject);
            }
        }
    }

}