using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitter : MonoBehaviour
{
    [SerializeField]private float Timer;

    public float[] bulletTimeline =
    {
        18.566f,19.233f,20.233f,20.566f,20.900f,
21.233f,21.566f,22.233f,22.566f,22.900f,23.233f,
23.566f,24.233f,24.566f,24.900f,25.233f,
25.566f,26.233f,26.566f,28.233f,28.566f,
28.900f,30.233f,30.400f,
30.566f,30.733f,30.900f,
32.233f,32.566f,
34.233f,34.566f,35.233f,35.566f,36.233f,36.566f,37.233f,
37.400f,37.566f,37.733f,38.233f,
38.566f,38.733f,39.233f,39.566f,
39.900f,69.900f,70.900f,71.900f,
72.900f,74.233f,74.566f,75.233f,75.566f,
75.900f,109.900f,110.233f,110.900f,111.233f,
111.900f,115.233f,115.566f,118.233f,119.233f,119.900f,
120.400f,120.900f,122.233f,122.566f,122.900f
    };
    public int index;
    
    //public GameObject EmptyObj;
    public GameObject Bullet;
    public Vector3 BulletForce;
    public float BulletForceTimes;

    public Vector3 moveDir;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Timer = -0.25f;
        index = 0;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //EmptyObj = GameObject.Find("EmptyObj");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (isBulletReady())
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            GameObject bullet = Instantiate(Bullet);
            bullet.transform.position = this.transform.position;
            //赋初始力
            bullet.GetComponent<Rigidbody2D>().AddForce(BulletForceTimes*BulletForce);

            //确定子弹位置
            //bullet.transform.parent = EmptyObj.transform;
        }

        //设置机关显示和隐藏的时间
        if ((Timer > 40f && Timer < 69f) || (Timer > 77f && Timer < 109f) || Timer>122f)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if ((Timer >= 69f && Timer <= 77f) ||((Timer >= 109f && Timer <= 122f)))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public bool isBulletReady()
    {
        if (index >= bulletTimeline.Length) return false;
        Timer += Time.deltaTime;
        if (Timer >= bulletTimeline[index])
        {
            index++;
            return true;
        }
        else return false;
    }

    public void Move()
    {
        transform.Translate(moveSpeed * Time.deltaTime * moveDir);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Wall") moveDir = -moveDir;
    }
}
