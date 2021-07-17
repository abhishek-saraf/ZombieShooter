using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.abhishek.saraf.ZombieSurvival
{
    public class ZombieController : MonoBehaviour
    {
        // Attributes.
        private float _speed = 2.5f;
        private float _speedIncrementValue = 0.5f;

        private float _speedIncrementTimer = 60.0f;

        private float _randomPosX = 16.0f, _randomPosZ = 8.0f;

        private float _spawnSpeed = 2.0f;

        private List<GameObject> _zombies;

        public List<GameObject> Zombies
        {
            get { return _zombies; }
        }

        [SerializeField] private GameObject _player;

        // Start is called before the first frame update
        void Start()
        {
            _zombies = new List<GameObject>();

            StartCoroutine(SpawnZombies());

            InvokeRepeating("IncreaseSpeed", _speedIncrementTimer, _speedIncrementTimer);
        }

        private void IncreaseSpeed()
        {
            _speed += _speedIncrementValue;
        }

        IEnumerator SpawnZombies()
        {
            while (true)
            {
                // GameObject zombie = Resources.Load<GameObject>("Zombie");

                GameObject zombie = AssetBundleManagerScript.instance.zombie;

                float zombieXPos = Random.Range(-_randomPosX, _randomPosX);
                float zombieZPos = Random.Range(-_randomPosZ, _randomPosZ);

                GameObject zombieGameObj = Instantiate(zombie, new Vector3(zombieXPos, 0.5f, zombieZPos), Quaternion.identity, gameObject.transform);
                zombieGameObj.transform.parent = gameObject.transform;

                _zombies.Add(zombieGameObj);

                yield return new WaitForSeconds(_spawnSpeed);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Player.instance.isPlayerDead) return;

            foreach (GameObject zombie in _zombies)
            {
                if (zombie != null)
                {
                    float step = _speed * Time.deltaTime;
                    zombie.transform.position = Vector3.MoveTowards(zombie.transform.position, _player.transform.position, step);

                    Vector3 targetDir = _player.transform.position - zombie.transform.position;
                    zombie.transform.rotation = Quaternion.Slerp(zombie.transform.rotation, Quaternion.LookRotation(targetDir), Time.deltaTime * 5.0f);
                }
            }
        }
    }
}
