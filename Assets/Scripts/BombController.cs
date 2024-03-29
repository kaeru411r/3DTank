﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>爆弾のコンポーネント</summary>
public class BombController : MonoBehaviour
{
    [Tooltip("爆風の力")]
    [SerializeField] float _explosionForce;
    [Tooltip("爆風の半径")]
    [SerializeField] float _explosionRadius;
    [Tooltip("基本ダメージ")]
    [SerializeField] float _damage;

    float Blast()
    {
        return ExplosionManager.Instance.AdvancedExplosion(_explosionForce, transform.position, _explosionRadius, _damage);
    }

    private void Update()
    {
        //Debug.Log($"{Blast()}ダメージ与えた");
    }
}
