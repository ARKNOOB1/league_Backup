using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controll : MonoBehaviour
{
    Rigidbody2D Erb;

    [Header("Bool")]
    [SerializeField] public bool isMove;
    [SerializeField] public bool isAttack;

    [Header("Animation")]
    [SerializeField] public Animator animator;

    [Header("HP")]
    [SerializeField] private float Ehp = 3;

    [Header("AI Move")]
    [SerializeField] private Transform PlayerCheck;
    [SerializeField] private Vector2 PlayerCheckSize = new Vector2(10f, 10f);
    [SerializeField] private float stopDistance = 1f;
    [SerializeField] public float mvSpd = 2f;
    [SerializeField] public int moveInput;

    [Header("AI Attack")]
    [SerializeField] private Transform attackCheck;
    [SerializeField] private Vector2 attackCheckSize = new Vector2(1.5f, 0.5f);
    [SerializeField] private float curtime;
    [SerializeField] public float cooltime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        Erb = GetComponent<Rigidbody2D>();
        isMove = true;
        isAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        AI();
    }

    public void E_Damaged(int Dm)
    {
        Ehp -= Dm;
        if(Ehp > 0)
        {
            animator.SetTrigger("dmg");
        }
        if(Ehp <= 0)
        {
            isMove = false;
            isAttack = false;
            animator.SetTrigger("die");
            Destroy(gameObject, 0.5f);
        }
    }

    void AI()
    {
        // 이동
        if (isMove)
        {
            Collider2D[] col = Physics2D.OverlapBoxAll(PlayerCheck.position, PlayerCheckSize, 0f);
            foreach (Collider2D plcol in col)
            {
                if(plcol.tag == "Player")
                {
                    moveInput = 0;
                    Vector2 direction = (plcol.transform.position - transform.position).normalized;
                    direction.y = 0;
                    if (Vector2.Distance(plcol.transform.position, transform.position) > stopDistance)
                    {
                        if(direction.x > 0)
                        {
                            transform.localScale = new Vector2(-1, 1);
                        }
                        if (direction.x < 0)
                        {
                            transform.localScale = new Vector2(1, 1);
                        }

                        Erb.velocity = direction * mvSpd;
                    }
                    
                }
            }
        }

        // 공격
        if (isAttack)
        {
            if (curtime > 0)
            {
                curtime -= Time.deltaTime;
            }
            if (curtime <= 0)
            {
                Collider2D[] col = Physics2D.OverlapBoxAll(attackCheck.position, attackCheckSize, 0f);
                foreach(Collider2D plcol in col)
                {
                    if(plcol.tag == "Player")
                    {
                        plcol.GetComponent<Player_Controller>().PL_Damaged(1);
                        animator.SetTrigger("atk");
                        Rigidbody2D pl = plcol.GetComponent<Rigidbody2D>();
                        pl.velocity = new Vector2(pl.transform.position.x, 3f);
                    }
                }
                curtime = cooltime;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(PlayerCheck.position, PlayerCheckSize);
        Gizmos.DrawWireCube(attackCheck.position, attackCheckSize);
    }
}
