using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    private Animator _animator;
    private float _lastAttackTime;
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player_ target)
    {
        _animator.Play("Attack");
        target.ApplyDamage(_damage);
    }
}
