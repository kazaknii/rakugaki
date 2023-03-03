using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayer;
    Rigidbody2D rb;
    Animator animator;
    int at = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("IsAttack");
        }
        MoveMent();
    }

    public void Attack()
    {

        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);
        foreach(Collider2D hitEnemy in hitEnemys)
        {
            hitEnemy.GetComponent<EnemyManager>().OnDamage(at);
        }
    }

    private void OnDrawGizmoSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackPoint.position, attackRadius);
    }

    void MoveMent()
    {
        float x = Input.GetAxisRaw("Horizontal");

        //キャラクター向き切り替え
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        animator.SetFloat("Speed", Mathf.Abs(x));
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
    }
  }
