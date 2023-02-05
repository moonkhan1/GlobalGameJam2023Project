using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MonkeyController : MonoBehaviour
{
    Transform _transform;
    EnemyController _enemyController;
    [SerializeField] Transform _destination;
    Animator _anim;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _enemyController = FindObjectOfType<EnemyController>();
        _anim = GetComponent<Animator>();
    }
    private void Start() {
        if(AnimalManager.Instance != null)
            AnimalManager.Instance.isBirdEscaped += MonekyMovement;
    }


    private void OnDisable()
    {
        AnimalManager.Instance.isBirdEscaped -= MonekyMovement;
    }

    private void MonekyMovement()
    {
        _anim.SetBool("isEscaped", true);
        _transform.DOMoveX(_destination.transform.position.x, 25f).OnComplete(()=>{
            Destroy(gameObject);
        });
    }
}
