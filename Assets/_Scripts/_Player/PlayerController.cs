using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts._Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputProvider _inputProvider;
        [SerializeField] private QuakePlayerMovementController _quakePlayerMovementController;
        [SerializeField] private PlayerInteractionController _playerInteractionController;

        public QuakePlayerMovementController QuakePlayerMovementController => _quakePlayerMovementController;
        public PlayerInteractionController PlayerInteractionController => _playerInteractionController;


        void Awake()
        {
            _quakePlayerMovementController.Initialize(_inputProvider);
            _playerInteractionController.Initialize(_inputProvider);
        }

        private void Update()
        {
            _quakePlayerMovementController.CustomUpdate();
            _playerInteractionController.CustomUpdate();
        }
    }
}