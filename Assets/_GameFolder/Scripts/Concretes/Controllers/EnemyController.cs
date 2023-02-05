using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using UnityEngine.AI;
using DG.Tweening;
// using CASP.SoundManager;
using PuzzlePlatformer.States;
using PuzzlePlatformer.States.EnemyState;

public class EnemyController : MonoBehaviour, IEnemy
{
    [SerializeField] public LayerMask _layer;
    [SerializeField] public Transform _fireTransform;
    [SerializeField] SplineFollower _splineFollower;
    public NavMeshAgent _navMesh;
    PlayerController _playerController;
    [SerializeField] public Transform _secondTarget;
    private Rigidbody _rb;
    [SerializeField] Transform _enemyTransform;
    private float _enemySpeed = 11f;
    private Sequence _seq;
    private bool isFollowingPlayer = false;
    public bool isInPatrol { get; set; }
    public bool isRunning = false;
    StateMachine _stateMachine;

    public Transform Target { get; set; }
    [SerializeField] private GameObject _key;
    Animator _anim;

    private void Awake()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _splineFollower = GetComponent<SplineFollower>();
        Target = FindObjectOfType<PlayerController>().transform;
        _rb = GetComponentInChildren<Rigidbody>();
        _stateMachine = new StateMachine();
        _enemyTransform = GetComponent<Transform>();
        _anim = GetComponent<Animator>();
    }
    private void Start()
    {
        _anim.SetBool("isPatroling", true);
        PatrolState patrolState = new PatrolState(this);
        ChaseState chaseState = new ChaseState(this);
        BackToPatrolState backToPatrolState = new BackToPatrolState(this);
        RunState runState = new RunState(this);

        _stateMachine.AddState(patrolState, chaseState, () => isFollowingPlayer);
        _stateMachine.AddState(chaseState, backToPatrolState, () => !isFollowingPlayer);
        _stateMachine.AddState(backToPatrolState, patrolState, () => isInPatrol);
        _stateMachine.AddState(patrolState, runState, () => isRunning);
        _stateMachine.SetState(patrolState);
    }

    void Update()
    {
        _stateMachine.StateControl();
    }


    void OnDrawGizmos()
    {

        RaycastHit hit;
        if (Physics.SphereCast(_enemyTransform.position, _enemyTransform.lossyScale.x * 1.2f, _enemyTransform.forward, out hit, 2f, _layer))
        {

            Gizmos.color = new Color(32, 32, 32, 0);
            Gizmos.DrawRay(_fireTransform.position, _fireTransform.forward * hit.distance);
            Gizmos.DrawWireSphere(_fireTransform.position + _fireTransform.forward * hit.distance, _enemyTransform.lossyScale.x * 1.2f);
            if (hit.transform.gameObject.layer == 6)
            {
                isFollowingPlayer = true;
            }

            if (hit.transform.gameObject.layer == 7)
            {
                isRunning = true;
                _key.transform.parent = null;
                _key.transform.tag = "Collectable";
                // _key.transform.DOJump(new Vector3(_key.transform.position.x, 5.15f, -0), 0.5f, 1, 0.5f);
                _anim.SetBool("isPatroling", false);
                _anim.SetBool("isRunning", true);
            }

        }

        else
        {

            Gizmos.color = new Color(32, 32, 32, 0);
            Gizmos.DrawRay(_fireTransform.position, _fireTransform.forward * 2f);
            if (isFollowingPlayer)
            {

                isFollowingPlayer = false;
            }

        }
    }

}





