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
                Player.instance.isPlayerDead = true;
            }
            else
            {
                Destroy(collision.collider.gameObject);
            }
        }
    }
}
