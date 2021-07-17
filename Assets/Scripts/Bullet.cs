using UnityEngine;

using System.Collections;

namespace com.abhishek.saraf.ZombieSurvival
{
    public class Bullet : MonoBehaviour
    {
        //Drag in the Bullet Emitter from the Component Inspector.
        [SerializeField] private GameObject _bulletEmitter;

        //Drag in the Bullet Prefab from the Component Inspector.
        [SerializeField] private GameObject _bullet;

        //Enter the Speed of the Bullet from the Component Inspector.
        [SerializeField] private float _bulletForwardForce;

        [SerializeField] private bool _isForward;

        [SerializeField] private bool _isAuto;

        [SerializeField] private int _pistolRoundsPerMagazine = 7, _rifleRoundsPerMagazine = 20;

        private int _pistolBulletsLeft, _rifleBulletsLeft;

        private int _pistolBulletDamage = 50, _rifleBulletDamage = 25;

        private float _pistolCoolDownTime = 0.5f;
        private float _rifleCoolDownTime = 1.0f;

        private float _pistolCoolDownTimer, _rifleCoolDownTimer;

        private GameObject _playerCamera;

        [SerializeField] private float _bulletImpactForce = 100.0f;

        // Use this for initialization
        void Start()
        {
            _playerCamera = Player.instance.myCamera;
            _pistolBulletsLeft = _pistolRoundsPerMagazine;
            _rifleBulletsLeft = _rifleRoundsPerMagazine;
        }

        // Update is called once per frame
        void Update()
        {
            if (_pistolCoolDownTimer > 0)
            {
                _pistolCoolDownTimer -= Time.deltaTime;
            }
            if (_pistolCoolDownTimer < 0)
            {
                _pistolCoolDownTimer = 0;
            }

            if (_rifleCoolDownTimer > 0)
            {
                _rifleCoolDownTimer -= Time.deltaTime;
            }
            if (_rifleCoolDownTimer < 0)
            {
                _rifleCoolDownTimer = 0;
            }

            CheckForReload();

            if (Input.GetMouseButtonDown(0))
            {
                
                if (!_isAuto && _pistolBulletsLeft > 0 && _pistolCoolDownTimer == 0)
                {
                    ShootBulletsFromPistol();
                    _pistolCoolDownTimer = _pistolCoolDownTime;
                }
            }

            if (_isAuto && _rifleBulletsLeft > 0 && _rifleCoolDownTimer == 0)
            {
                ShootBulletsAuto();
                _rifleCoolDownTimer = _rifleCoolDownTime;
            }
        }

        private void CheckForReload()
        {
            // Need to press 'R' in order to reload the gun(s).
            if (Input.GetKeyDown(KeyCode.R))
            {
                ReloadPistol();
                ReloadRifle();
            }
        }

        private void ReloadPistol()
        {
            _pistolBulletsLeft = _pistolRoundsPerMagazine;
        }

        private void ReloadRifle()
        {
            _rifleBulletsLeft = _rifleRoundsPerMagazine;
        }

        private void ShootBulletsFromPistol()
        {
            //The Bullet instantiation happens here.
            GameObject temporaryBulletHandler;
            temporaryBulletHandler = Instantiate(_bullet, _bulletEmitter.transform.position, _bulletEmitter.transform.rotation);

            temporaryBulletHandler.transform.rotation = Player.instance.myCamera.transform.rotation;

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody temporaryRigidBody;
            temporaryRigidBody = temporaryBulletHandler.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            temporaryRigidBody.AddForce(_playerCamera.transform.forward * _bulletForwardForce);

            _pistolBulletsLeft -= 1;

            //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
            Destroy(temporaryBulletHandler, 3.0f);

            RaycastHit hit;

            if (Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, out hit, 10.0f))
            {
                Zombie zombie = hit.transform.GetComponent<Zombie>();
                if (zombie != null)
                {
                    zombie.TakeDamage(_pistolBulletDamage);
                }
                
                if (hit.rigidbody !=  null)
                {
                    hit.rigidbody.AddForce(-hit.normal * _bulletImpactForce);
                }
            }
        }

        private void ShootBulletsFromRifle()
        {
            //The Bullet instantiation happens here.
            GameObject temporaryBulletHandler;
            temporaryBulletHandler = Instantiate(_bullet, _bulletEmitter.transform.position, _bulletEmitter.transform.rotation);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody temporaryRigidBody;
            temporaryRigidBody = temporaryBulletHandler.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            temporaryRigidBody.AddForce(_playerCamera.transform.forward * _bulletForwardForce);

            _rifleBulletsLeft -= 1;

            //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
            Destroy(temporaryBulletHandler, 3.0f);

            RaycastHit hit;

            if (Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, out hit, 10.0f))
            {
                Zombie zombie = hit.transform.GetComponent<Zombie>();
                if (zombie != null)
                {
                    zombie.TakeDamage(_rifleBulletDamage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * _bulletImpactForce);
                }
            }
        }

        private void ShootBulletsAuto()
        {
            if (Input.GetMouseButton(0))
            {
                for (int i = 0; i < 4; i++)
                {
                    ShootBulletsFromRifle();
                }
            }
        }
    }
}
