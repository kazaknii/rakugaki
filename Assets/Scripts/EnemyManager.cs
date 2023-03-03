using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //github 更新テスト
    public int hp;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnDamage(int damage)
    {
        hp -= damage;
        animator.SetTrigger("IsHurt");
        if (hp <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        hp = 0;
        animator.SetTrigger("Die");

    }
}
