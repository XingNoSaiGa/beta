using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    private Rigidbody2D rigidbody;
    private BoxCollider2D colider;
    public GameObject rot;


    public float moveSpeed = 5;
    private Vector2 targetPosition;
    private Transform player;
    enemyData data = new enemyData();
    private Animator animator;
    public int HP;
    public int ATK;
    public float attackSpeed;

    private float timer = 0;
    public List<Transform> position = new List<Transform>();


    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        colider = GetComponent<BoxCollider2D>();
        targetPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;//获得主角位置（2）
        animator = GetComponent<Animator>();


    }
    class enemyData
    {
        public float step = 0;
        public int oretation = 1;//1代表顺时针，0代表逆时针
        public float moveDistance = 0;
        public float clock = 0;
        public float searchTime = 0;
        public int i = 0;
        public float distance;
        public int enemyState = 0;//敌人的状态

    }
    // Update is called once per frame
    void Update()
    {
        timer += attackSpeed * Time.deltaTime;
        if (HP <= 0)
            Destroy(this.gameObject);

        Vector2 offset = player.position - transform.position;//获得主角位置与怪物位置的偏差
        if (offset.magnitude < 1.1f)/*偏差*/
        {
            if (timer > 1)
            {
                //攻击
                tags.pHP--;
                animator.SetTrigger("Attack");//得到播放敌人攻击动画
                player.SendMessage("TakeDamage", ATK);
                timer = 0;
            }
        }

        data.step = moveSpeed * Time.deltaTime;

        //判断主角是否在怪物巡视范围内
        data.searchTime += Time.deltaTime;
        if (searchDistance(player.position.x,player.position.y) < 5)
        {
            rot.SetActive(false);
            data.enemyState = 1;
            data.searchTime = 0;
        }
        else if (data.searchTime > 3)
        {
            rot.SetActive(true);
            data.enemyState = 0;
        }


        switch (data.enemyState)
        {
            case 0:
                patrol(data);
                break;
            case 1:
                trace(data);
                break;
            default:
                break;
        }
    }

    void patrol(enemyData date)
    {

        if (date.i < position.Count)
        {
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(position[date.i].position.x, position[date.i].position.y, 0), date.step);
            if (searchDistance(position[date.i].position.x,position[date.i].position.y) < 1)
            {
                if (date.oretation == 1)
                    date.i = (date.i + 1) % position.Count;
                else
                    date.i = (date.i + position.Count - 1) % position.Count;
            }

            date.clock += Time.deltaTime;
            if (date.clock > 2)
            {
                float x, y;
                if (transform.position.x > targetPosition.x)
                    x = transform.position.x - targetPosition.x;
                else
                    x = targetPosition.x - transform.position.x;
                if (transform.position.y > targetPosition.y)
                    y = transform.position.y - targetPosition.y;
                else
                    y = targetPosition.y - transform.position.y;

                date.clock = 0;

                date.moveDistance += x + y;
                targetPosition = transform.position;
                date.distance = Random.Range(10, 20);
            }
            if (date.moveDistance > date.distance)
            {
                date.moveDistance = 0;
                date.oretation = (date.oretation + 1) % 2;
                if (date.oretation == 1)
                {

                    date.i = (date.i + 1) % position.Count;
                }
                else
                    date.i = (date.i + position.Count - 1) % position.Count;
            }
        }

    }
    void trace(enemyData date)
    {
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, player.position, date.step);

    }
    float searchDistance(float positionX,float positionY)
    {
        float x = transform.position.x - positionX;
        float y = transform.position.y - positionY;

        if (x < 0)
            x = -x;
        if (y < 0)
            y = -y;

        return ((x * x) + (y * y));
    }
}
