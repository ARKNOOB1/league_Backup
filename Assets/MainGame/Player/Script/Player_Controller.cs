using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D rb;

    public Save save;

    [Header("UI")]
    [SerializeField] public GameObject UI;
    [SerializeField] public Slider OxTank;
    [SerializeField] public Text OxText;
    [SerializeField] public GameObject flash;
    [SerializeField] public Text timer;
    [SerializeField] public GameObject timeStop;
    public bool isOn = false;
    public GameObject shop;

    public int coin;

    [Header("HP")]
    [SerializeField] public Slider HpBar;
    [SerializeField] public float HP = 6;

    [Header("GrounCheck")]
    [SerializeField] private float checkDistance = 0.1f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.5f, 0.1f);
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGround;

    [Header("Animation")]
    [SerializeField] public Animator mvAnime;
    [SerializeField] public Animator atAnime;

    [Header("PlayerMove")]
    [SerializeField] public int moveInput;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float jumpForce = 7f;

    [Header("Attack")]
    [SerializeField] private Transform attackCheck;
    [SerializeField] private Vector2 attackCheckSize = new Vector2(1.5f, 1f);
    [SerializeField] private float curtime;
    [SerializeField] public float cooltime = 0.5f;

    [Header("Inventory")]
    [SerializeField] private Transform itemCheck;
    [SerializeField] private Vector2 itemCheckSize = new Vector2(2f, 1f);
    public bool isAppend1 = gameManager.instance.SlotO1;
    public bool isAppend2 = gameManager.instance.SlotO2;
    public Inventory_Controll Items;
    public GameObject itemSlot1;
    public GameObject itemSlot2;
    public GameObject itemSlot3;
    public GameObject itemSlot4;
    int i = 0;
    public Item item;
    public ItemData itemData;
    public List<Dictionary<int, Item>> itemList = new List<Dictionary<int, Item>>(8);

    public float _curtime = 10f;

    public bool tagChange;

    public int weight = 0;
    public int price1 = 0;
    public int price2 = 0;
    public int price3 = 0;
    public int price4 = 0;
    public int price5 = 0;
    public int price6 = 0;
    public int price7 = 0;
    public int price8 = 0;

    public int itemWeight1;
    public int itemWeight2;
    public int itemWeight3;
    public int itemWeight4;
    public int itemWeight5;
    public int itemWeight6;
    public int itemWeight7;
    public int itemWeight8;

    public Image itemImage1;
    public Image itemImage2;
    public Image itemImage3;
    public Image itemImage4;
    public Image itemImage5;
    public Image itemImage6;
    public Image itemImage7;
    public Image itemImage8;

    public Sprite Slot1;
    public Sprite Slot2;
    public Sprite Slot3;
    public Sprite Slot4;
    public Sprite Slot5;
    public Sprite Slot6;
    public Sprite Slot7;
    public Sprite Slot8;


    public Sprite Psprite;


    [Header("Teleport")]
    [SerializeField] public GameObject tel1;
    [SerializeField] public GameObject tel2;
    [SerializeField] public GameObject tel3;
    [SerializeField] public GameObject tel4;
    [SerializeField] public GameObject tel5;
    public int ii = 1;

    [Header("GameOver")]
    [SerializeField] public GameObject gameOver;
    [SerializeField] public Text totalTime;
    [SerializeField] public Text Rank;
    [SerializeField] public GameObject GrenadePrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameOver.SetActive(false);
        UI.SetActive(true);

        timeStop.SetActive(false);
        gameManager.instance.time = 0;
        gameManager.instance.SaveOxy = gameManager.instance.Oxygen;


    }

    // Update is called once per frame
    void Update()
    {
        GrCheck();
        Timer();
        Anime();
        Oxygen();
        Move();
        Jump();
        FlashLight();
        Attack();
        Inventory();
        CheatKey();
        SellItem();
        gameManager.instance.coin = coin;
        isAppend1 = gameManager.instance.SlotO1;
        isAppend2 = gameManager.instance.SlotO2;
        if (isAppend1)
        {
            itemSlot1.SetActive(true);
            itemSlot2.SetActive(true);
        }
        if (isAppend2)
        {
            itemSlot3.SetActive(true);
            itemSlot4.SetActive(true);
        }
        if (isAppend1 == false)
        {
            itemSlot1.SetActive(false);
            itemSlot2.SetActive(false);
        }
        if (isAppend2 == false)
        {
            itemSlot3.SetActive(false);
            itemSlot4.SetActive(false);
        }
        if (gameManager.instance.shopShower)
        {
            shop.SetActive(true);
        }
        else
        {
            shop.SetActive(false);
        }
        HpBar.value = HP / 6;
    }

    public void PL_Damaged(int Dm)
    {
        HP -= Dm;
        HpBar.value = HP / 6;
        if(HP <= 0)
        {
            GameOver();
        }
    }

    void Timer()
    {
        int timeM = (int)gameManager.instance.time / 60;
        int timeS = (int)gameManager.instance.time % 60;
        timer.text = "TIMER: " + timeM.ToString("D2") + ":" + timeS.ToString("D2");
    }
    void Oxygen()
    {
        OxTank.value = gameManager.instance.Oxygen / gameManager.instance.SaveOxy;

        OxText.text = gameManager.instance.Oxygen.ToString("F0");
        if(OxTank.value <= 0)
        {
            GameOver();
        }
    }

    private void Move()
    {
        moveInput = 0;
        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1;
            transform.localScale = new Vector2(-1, 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1;
            transform.localScale = new Vector2(1, 1);
        }
        if (weight > gameManager.instance.MaxWeight / 2)
        {
            rb.velocity = new Vector2(moveInput * (moveSpeed/2), rb.velocity.y);
            return;
        }
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        
    }

    void Jump()
    {
        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        
    }

    void FlashLight()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flash.SetActive(!flash.activeSelf);
        }
    }

    void Attack()
    {
        if(curtime > 0)
        {
            curtime -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (curtime <= 0)
            {
                atAnime.SetTrigger("atk");
                Collider2D[] AtCol = Physics2D.OverlapBoxAll(attackCheck.position, attackCheckSize, 0f);
                foreach (Collider2D col in AtCol)
                {
                    if (col.tag == "Enemy")
                    {
                        col.GetComponent<Enemy_Controll>().E_Damaged(1);
                    }
                    if (col.tag == "FixedEnemy")
                    {
                        col.GetComponent<Fixed_Enemy_Controll>().E_Damaged(1);
                    }
                }
                curtime = cooltime;
            }
            
        }

        // Grenade Attack
        if (Input.GetKeyDown(KeyCode.G))
        {
            ShootGrenade();
        }
    }

    void ShootGrenade()
    {
        if (gameManager.instance.grCount <= 0)
        {
            return;
        }
        gameManager.instance.grCount--;
        GameObject grenade = Instantiate(GrenadePrefab, transform.position, Quaternion.identity);
        Rigidbody2D grenadeRb = grenade.GetComponent<Rigidbody2D>();

        if((Vector2)transform.localScale == new Vector2(-1, 1))
        {
            grenade.transform.rotation = Quaternion.Euler(0f, 0f, 135f);
            grenadeRb.velocity = new Vector2(-5f, 7f);
        }
        if ((Vector2)transform.localScale == new Vector2(1, 1))
        {
            grenade.transform.rotation = Quaternion.Euler(0f, 0f, 45f);
            grenadeRb.velocity = new Vector2(5f, 7f);
        }
    }

    void Inventory()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D[] col = Physics2D.OverlapBoxAll(itemCheck.position, itemCheckSize, 0f);
            foreach (var item in col)
            {
                if(item.tag == "item")
                {
                    ItemGet(item.gameObject);
                    SlotSave(item);
                }
                else if(item.tag == "OxyJar")
                {
                    Oxy();
                    Destroy(item.gameObject);
                }
                else if(item.tag == "HpJar")
                {
                    Hp();
                    Destroy(item.gameObject);
                }
                else if(item.tag == "Invoked")
                {
                    Destroy(item.gameObject);
                }
            }
        }
    }

    public void Oxy()
    {
        gameManager.instance.Oxygen += 40;
    }

    public void Hp()
    {
        HP += 2;
    }



    public void ItemGet(GameObject itemO)
    {
        GameObject Obj = itemO.gameObject;

        string _name = Obj.GetComponent<ItemData>().itemName;
        weight += Obj.GetComponent<ItemData>().itemWeight;
        
        Sprite sprite = Obj.GetComponent<ItemData>().itemSprite;
        Psprite = sprite;
        
    }

    void SlotSave(Collider2D col)
    {

        if (itemImage1.sprite == null)
        {
            Slot1 = Psprite;
            price1 = col.GetComponent<ItemData>().itemPrice;
            itemWeight1 = col.GetComponent<ItemData>().itemWeight;
            itemImage1.sprite = Psprite;
        }
        else if (itemImage2.sprite == null)
        {
            Slot2 = Psprite;
            price2 = col.GetComponent<ItemData>().itemPrice;
            itemWeight2 = col.GetComponent<ItemData>().itemWeight;
            itemImage2.sprite = Psprite;
        }
        else if (itemImage3.sprite == null)
        {
            Slot3 = Psprite;
            price3 = col.GetComponent<ItemData>().itemPrice;
            itemWeight3 = col.GetComponent<ItemData>().itemWeight;
            itemImage3.sprite = Psprite;
        }
        else if (itemImage4.sprite == null)
        {
            Slot4 = Psprite;
            price4 = col.GetComponent<ItemData>().itemPrice;
            itemWeight4 = col.GetComponent<ItemData>().itemWeight;
            itemImage4.sprite = Psprite;
        }
        else if (itemImage5.sprite == null && isAppend1)
        {
            Slot5 = Psprite;
            price5 = col.GetComponent<ItemData>().itemPrice;
            itemWeight5 = col.GetComponent<ItemData>().itemWeight;
            itemImage5.sprite = Psprite;
        }
        else if (itemImage6.sprite == null && isAppend1)
        {
            Slot6 = Psprite;
            price6 = col.GetComponent<ItemData>().itemPrice;
            itemWeight6 = col.GetComponent<ItemData>().itemWeight;
            itemImage6.sprite = Psprite;
        }
        else if (itemImage7.sprite == null && isAppend2)
        {
            Slot7 = Psprite;
            price7 = col.GetComponent<ItemData>().itemPrice;
            itemWeight7 = col.GetComponent<ItemData>().itemWeight;
            itemImage7.sprite = Psprite;
        }
        else if (itemImage8.sprite == null && isAppend2)
        {
            Slot8 = Psprite;
            price8 = col.GetComponent<ItemData>().itemPrice;
            itemWeight8 = col.GetComponent<ItemData>().itemWeight;
            itemImage8.sprite = Psprite;
        }
        Destroy(col.gameObject);
    }


    void SellItem()
    {
        if (gameManager.instance.shopShower)
        {
            if (Slot1 != null)
            {
                weight -= itemWeight1;
                coin += price1;
                Slot1 = null;
            }
            else if (Slot2 != null)
            {
                weight -= itemWeight2;
                coin += price2;
                Slot2 = null;
            }
            else if (Slot3 != null)
            {
                weight -= itemWeight3;
                coin += price3;
                Slot3 = null;
            }
            else if (Slot4 != null)
            {
                weight -= itemWeight4;
                coin += price4;
                Slot4 = null;
            }
            else if (Slot5 != null)
            {
                weight -= itemWeight5;
                coin += price5;
                Slot5 = null;
            }
            else if (Slot6 != null)
            {
                weight -= itemWeight6;
                coin += price6;
                Slot6 = null;
            }
            else if (Slot7 != null)
            {
                weight -= itemWeight7;
                coin += price7;
                Slot7 = null;
            }
            else if (Slot8 != null)
            {
                weight -= itemWeight8;
                coin += price8;
                Slot8 = null;
            }

        }
    }

    public void CheatKey()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            gameManager.instance.Oxygen = gameManager.instance.SaveOxy;
            HP = 6;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            gameManager.instance.itFree = true;
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            SceneManager.LoadScene("MainGame");
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            CheatKeyFour();
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            isOn = !isOn;

            if (!isOn)
            {
                timeStop.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                timeStop.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    void CheatKeyFour()
    {
        if(i == 1)
        {
            transform.position = tel1.transform.position;
            i++;
            return;
        }
        else if (i == 2)
        {
            transform.position = tel2.transform.position;
            i++;
            return;
        }
        else if (i == 3)
        {
            transform.position = tel3.transform.position;
            i++;
            return;
        }
        else if (i == 4)
        {
            transform.position = tel4.transform.position;
            i++;
            return;
        }
        else if (i == 5)
        {
            transform.position = tel5.transform.position;
            i = 1;
            return;
        }
    }

    void GameOver()
    {
        
        gameOver.SetActive(true);
        Destroy(gameObject);

        gameManager.instance.clear = false;
        int timeM = (int)gameManager.instance.time / 60;
        int timeS = (int)gameManager.instance.time % 60;
        totalTime.text = "TOTAL TIME: "+ timeM.ToString("D2") + ":" + timeS.ToString("D2");
    }

    void Anime()
    {
        if(!isGround && rb.velocity.y > 0)
        {
            mvAnime.Play("Jump");
        }
        else if(moveInput != 0)
        {
            mvAnime.Play("Walk");
        }
        else if(moveInput == 0)
        {
            mvAnime.Play("Idle");
        }
    }

    

    void GrCheck()
    {
        Collider2D col = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, groundLayer);
        isGround = col != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
        Gizmos.DrawWireCube(attackCheck.position, attackCheckSize);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(itemCheck.position, itemCheckSize);
    }
}
