using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UdemyProject2.Concretes.Combats;
using UdemyProject2.Controllers;
using UnityEngine;

namespace UdemyProject2.Managers
{
    public class CheckpointManager : MonoBehaviour
    {

        [SerializeField]
        CheckPointController[] _checkPointControllers;
        Health _health;
        private void Awake()
        {
         _checkPointControllers = GetComponentsInChildren<CheckPointController>();
            _health = FindObjectOfType<PlayerController>().GetComponent<Health>();

        }

        private void Start()
        {

            _health.OnHealthChanged += HandleHealthChanged;
        }

        private void HandleHealthChanged()
        {
            _health.transform.position = _checkPointControllers.LastOrDefault(x => x.IsPassed).transform.position;

        }
    }
}

