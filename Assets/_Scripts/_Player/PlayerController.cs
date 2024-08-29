using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts._InputSystem;
using UnityEngine;

namespace _Scripts._Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputProvider _inputProvider;
        [SerializeField] private QuakePlayerMovementController _quakePlayerMovementController;
        [SerializeField] private PlayerInventory _playerInventory;
        [SerializeField] private PlayerInteractionController _playerInteractionController;

        public QuakePlayerMovementController QuakePlayerMovementController => _quakePlayerMovementController;
        public PlayerInteractionController PlayerInteractionController => _playerInteractionController;


        void Awake()
        {
            _playerInventory.Initialize(_inputProvider);
            _quakePlayerMovementController.Initialize(_inputProvider);
            _playerInteractionController.Initialize(_inputProvider, _playerInventory);
        }

        private void Update()
        {
            _quakePlayerMovementController.CustomUpdate();
            _playerInteractionController.CustomUpdate();
        }
    }
}