using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fixed_Enemy_Controll : MonoBehaviour
{
    Rigidbody2D Ferb;

    [Header("Bool")]
    [SerializeField] public bool isAttack;

    [Header("Animation")]
    [SerializeField] public Animator animator;

    [Header("HP")]
    [SerializeField] private float Fehp = 3;


    [Header("AI Attack")]
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] private Transform attackCheck;
    [SerializeField] private Vector2 attackCheckSize = new Vector2(15f, 15f);
    [SerializeField] private float curtime;
    [SerializeField] public float cooltime = 3f;
    [SerializeField] public float ShootSpd = 7f;

    // Start is called before the first frame update
    void Start()
    {
        Ferb = GetComponent<Rigidbody2D>();
        isAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        AI();
    }

    public void E_Damaged(int Dm)
    {
        Fehp -= Dm;
        if (Fehp > 0)
        {
            animator.SetTrigger("dmg");
        }
        if (Fehp <= 0)
        {
            isAttack = false;
            animator.SetTrigger("die");
            Destroy(gameObject, 0.5f);
        }
    }

    void AI()
    {
        // АјАн
        if (isAttack)
        {
            if (curtime > 0)
            {
                curtime -= Time.deltaTime;
            }
            if (curtime <= 0)
            {
                Collider2D[] col = Physics2D.OverlapBoxAll(attackCheck.position, attackCheckSize, 0f);
                foreach (Collider2D plcol in col)
                {
                    if (plcol.tag == "Player")
                    {
                        animator.SetTrigger("atk");
                        ShootBullet(plcol);
                        curtime = cooltime;
                    }
                }
                
            }
        }
    }

    void ShootBullet(Collider2D Col)
    {
        GameObject Bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D BulletRb = Bullet.GetComponent<Rigidbody2D>();

        Vector2 direction = (Col.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
        BulletRb.velocity = direction * ShootSpd;

        if (direction.x > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (direction.x < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(attackCheck.position, attackCheckSize);
    }
}
