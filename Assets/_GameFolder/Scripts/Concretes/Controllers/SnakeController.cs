using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SnakeController : MonoBehaviour
{
    Transform _transform;
    EnemyController _enemyController;
    [SerializeField] Transform _destination;
    [SerializeField] private GameObject icon;
    Animator _anim;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _enemyController = FindObjectOfType<EnemyController>();
        _anim = GetComponent<Animator>();
    }
    private void Start() {
        if(AnimalManager.Instance != null)
            AnimalManager.Instance.isFireExtinguished += SnakeMovement;
    }
    private void Update() {
        if(_enemyController.isRunning)
        {
            _transform.DOMoveX(_destination.transform.position.x, 65f).OnComplete(()=>{
            Destroy(gameObject);
        });
        } 
    }

    private void OnDisable()
    {
        AnimalManager.Instance.isFireExtinguished -= SnakeMovement;
    }

    private void SnakeMovement()
    {
        _transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
        _transform.GetComponentInChildren<Collider>().enabled = true;
        icon.SetActive(false);
        Debug.Log("Snake");
    }
}
