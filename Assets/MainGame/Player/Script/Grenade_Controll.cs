using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade_Controll : MonoBehaviour
{
    Rigidbody2D rb;

    public ParticleSystem Explovise;
    [SerializeField] private Transform ExplosivePosition;
    private Vector2 ExplosiveRange = new Vector2(5f, 5f);

    private float curtime = 3f;
    public float cooltime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(curtime > 0)
        {
            curtime -= Time.deltaTime;
        }
        if(curtime <= 0)
        {
            SpriteRenderer gr = rb.GetComponent<SpriteRenderer>();
            gr.color -= gr.color;
            rb.velocity = Vector2.zero;
            Collider2D[] col = Physics2D.OverlapBoxAll(ExplosivePosition.position, ExplosiveRange, 0f);
            foreach (var entity in col)
            {
                if(entity.tag == "Player")
                {
                    entity.GetComponent<Player_Controller>().PL_Damaged(5);
                }
                if (entity.tag == "Enemy")
                {
                    entity.GetComponent<Enemy_Controll>().E_Damaged(5);
                }
                if (entity.tag == "FixedEnemy")
                {
                    entity.GetComponent<Fixed_Enemy_Controll>().E_Damaged(5);
                }
                curtime = cooltime;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(ExplosivePosition.position, ExplosiveRange);
    }
}
