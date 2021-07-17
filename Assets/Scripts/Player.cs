using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using TMPro;


namespace com.abhishek.saraf.ZombieSurvival
{
    public class Player : MonoBehaviour
    {
        // Attributes.
        public static Player instance;

        public int score;

        private int _health = 125;
        private GameObject _playerCursor;

        GameObject pistolObj, rifleObj;

        public bool isPlayerDead = false;

        public GameObject myCamera;

        [SerializeField] private Slider _healthSlider;

        [SerializeField] private GameObject _pointer, _pointerEnemy;

        [SerializeField] private TextMeshProUGUI _scoreCounter, _gameOverKillCounter;

        [SerializeField] private GameObject _zombies;

        private void Awake()
        {
            instance = this;
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public GameObject PlayerCursor
        {
            get { return _playerCursor; }
            set { _playerCursor = value; }
        }

        // Start is called before the first frame update
        void Start()
        {
            // GameObject pistol = Resources.Load<GameObject>("Pistol");
            GameObject pistol = AssetBundleManagerScript.instance.pistol;

            // GameObject rifle = Resources.Load<GameObject>("AK-47");
            GameObject rifle = AssetBundleManagerScript.instance.rifle;

            Vector3 pistolPosition = new Vector3(-0.349f, 0.0f, -0.549f);
            Vector3 riflePosition = new Vector3(-0.287f, 0.207f, -0.485f);

            Quaternion pistolRotation = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
            Quaternion rifleRotation = gameObject.transform.rotation;

            pistolObj = Instantiate(pistol, pistolPosition, pistolRotation, gameObject.transform);
            rifleObj = Instantiate(rifle, riflePosition, rifleRotation, gameObject.transform);

            HideRifle();
            ShowPistol();
        }

        private void HideRifle()
        {
            rifleObj.SetActive(false);
        }

        private void HidePistol()
        {
            pistolObj.SetActive(false);
        }

        private void ShowRifle()
        {
            rifleObj.SetActive(true);
        }

        private void ShowPistol()
        {
            pistolObj.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {
            _scoreCounter.text = score.ToString();
            _gameOverKillCounter.text = score.ToString();

            CheckForDeath();

            if (!isPlayerDead)
            {
                CheckForPointer();

                CheckHealth();

                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    SwitchToPistol();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    SwitchToRifle();
                }
            }
        }

        private void CheckForPointer()
        {
            RaycastHit hitInfo;

            if (Physics.Raycast(myCamera.transform.position, myCamera.transform.forward, out hitInfo, 10.0f))
            {
                Zombie zombie = hitInfo.transform.GetComponent<Zombie>();
                if (zombie != null)
                {
                    _pointer.SetActive(false);
                    _pointerEnemy.SetActive(true);
                }
            }
            else
            {
                _pointer.SetActive(true);
                _pointerEnemy.SetActive(false);
            }
        }

        private void CheckHealth()
        {
            _healthSlider.value = _health;
        }

        private void CheckForDeath()
        {
            if (_health <= 0)
            {
                foreach (GameObject zombie in _zombies.GetComponent<ZombieController>().Zombies)
                {
                    if (zombie != null) zombie.SetActive(false);
                }

                _zombies.SetActive(false);

                Destroy(gameObject);
                isPlayerDead = true;
            }
        }

        private void SwitchToPistol()
        {
            HideRifle();
            ShowPistol();
        }

        private void SwitchToRifle()
        {
            HidePistol();
            ShowRifle();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.gameObject.tag.Equals("Zombie"))
            {
                if (!isPlayerDead)
                {
                    _health -= 30;
                }
            }
        }
    }
}
