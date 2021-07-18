using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace com.abhishek.saraf.ZombieSurvival
{
    public class UIController : MonoBehaviour
    {
        // Singleton instance.
        public static UIController instance;

        // Reference to the HUD, start panel, game over panel, etc.
        [SerializeField] private GameObject _hud, _startPanel, _gameOverPanel, _playerUIPanel, _player, _zombies;

        private bool _isHudEnabled, _gameStarted;

        public bool IsGameStarted
        {
            get { return _gameStarted; }
        }

        // Start is called before the first frame update
        void Start()
        {
            _startPanel.SetActive(true);
            _playerUIPanel.SetActive(false);
            _gameOverPanel.SetActive(false);
            _player.SetActive(false);
            _zombies.SetActive(false);
            _hud.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            CheckForPlayerDeath();
            if (Input.GetKeyDown(KeyCode.U) && _gameStarted && !Player.instance.isPlayerDead)
            {
                ToggleHubVisibility();
            }
        }

        private void CheckForPlayerDeath()
        {
            if (_gameStarted)
            {
                if (Player.instance.isPlayerDead)
                {
                    _hud.SetActive(false);
                    _playerUIPanel.SetActive(false);
                    _gameOverPanel.SetActive(true);
                }
            }
        }

        private void ToggleHubVisibility()
        {
            _isHudEnabled = !_isHudEnabled;

            _hud.SetActive(_isHudEnabled);
        }

        public void StartGame()
        {
            _startPanel.SetActive(false);
            _playerUIPanel.SetActive(true);
            _player.SetActive(true);
            _zombies.SetActive(true);
            _gameStarted = true;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            _startPanel.SetActive(false);
            _player.SetActive(true);
            _zombies.SetActive(true);
            _gameStarted = true;
        }
    }
}
