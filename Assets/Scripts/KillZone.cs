using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.abhishek.saraf.ZombieSurvival
{
    public class KillZone : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.gameObject.tag.Equals("Player"))
            {
                Debug.Log("Player fell down!");
                Player.instance.isPlayerDead = true;
            }
            else
            {
                Debug.Log("Zombie fell down!");
                Destroy(collision.collider.gameObject);
            }
        }
    }
}
