using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PuzzlePlatformer.Abstract.States;
using UnityEngine.AI;
using Dreamteck.Splines;

namespace PuzzlePlatformer.States.EnemyState
{
    public class RunState : IState
    {
        NavMeshAgent _navMeshAgent;
        Transform _target;
        EnemyController _enemyController;
        SplineFollower _splineFollower;

        public RunState(EnemyController enemyController)
        {
            _navMeshAgent = enemyController.GetComponent<NavMeshAgent>();
            _splineFollower = enemyController.GetComponent<SplineFollower>();
            _target = enemyController._secondTarget;
            _enemyController = enemyController;
        }
        public void OnExit()
        {
            Debug.Log($"{nameof(RunState)}{nameof(OnExit)}");
        }

        public void OnStart()
        {
            Debug.Log($"{nameof(RunState)}{nameof(OnStart)}");
        }

        public void StateControl()
        {
            _splineFollower.follow = false;
            _enemyController.isInPatrol = false;
            _navMeshAgent.SetDestination(_target.transform.position);
            _navMeshAgent.speed = 8;
        }

    }
}