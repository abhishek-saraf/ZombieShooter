using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.abhishek.saraf.ZombieSurvival
{
    public class PowerUps : MonoBehaviour
    {
        private float _spawnTime = 45.0f;

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("SpawnPowerUps", 5.0f, _spawnTime);
        }

        private void SpawnPowerUps()
        {
            float powerUpXPos = Random.Range(-16, 16);
            float powerUpZPos = Random.Range(-8, 8);

            GameObject powerup = Resources.Load<GameObject>("PowerUp");

            GameObject powerupGameObj = Instantiate(powerup, new Vector3(powerUpXPos, 0.5f, powerUpZPos), Quaternion.identity);
            powerupGameObj.transform.parent = gameObject.transform;

            Destroy(powerupGameObj, 5.0f);
        }
    }
}
