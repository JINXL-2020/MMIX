using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitter1 : MonoBehaviour
{
    [SerializeField] private float Timer;

    public float[] bulletTimeline =
    {
        17.900f,19.900f,21.900f,23.900f,25.900f,
        26.900f,27.233f,27.400f,27.566f,27.900f,
        28.900f,29.066f,29.233f,29.400f,29.566f,
        29.733f,29.900f,30.900f,30.983f,31.066f,
        31.150f,31.233f,31.316f,31.400f,31.483f,
        31.566f,31.650f,31.733f,31.900f,32.900f,
        32.983f,33.066f,33.150f,33.233f,33.316f,
        33.400f,33.483f,33.566f,33.650f,33.733f,
        33.900f,34.900f,35.900f,36.900f,37.900f,
        38.900f,39.900f,69.900f,69.983f,70.066f,
        70.150f,70.233f,70.316f,70.400f,70.483f,
        70.566f,70.650f,70.733f,70.816f,70.900f,
        70.983f,71.066f,71.150f,71.233f,71.316f,
        71.400f,71.483f,71.566f,71.900f,71.983f,
        72.066f,72.150f,72.233f,72.316f,72.400f,
        72.483f,72.566f,72.650f,72.733f,72.816f,
        72.900f,72.983f,73.066f,73.150f,73.233f,
        73.316f,73.400f,73.483f,73.566f,73.900f,
        74.900f,75.900f,75.955f,76.011f,76.066f,
        76.122f,76.177f,76.233f,76.288f,76.344f,
        76.400f,76.455f,76.511f,76.566f,76.622f,
        76.677f,76.733f,76.788f,76.844f,76.900f,
        76.955f,109.900f,110.566f,110.788f,110.900f,
        111.566f,111.788f,111.900f,112.900f,113.233f,
        113.344f,113.455f,113.566f,113.900f,114.900f,
        115.900f,116.900f,117.900f,118.566f,118.788f,
        118.900f,119.566f,119.788f,119.900f,120.400f,
        120.566f,120.733f,120.900f,121.011f,121.122f,
        121.233f,121.344f,121.455f,121.566f,121.677f,
        121.788f,121.900f,122.900f
    };
    public int[] bulletType =
    {
        2,2,2,2,2,
        2,1,1,1,2,
        1,1,1,1,1,
        1,2,1,1,1,
        1,1,1,1,1,
        1,1,1,2,1,
        1,1,1,1,1,
        1,1,1,1,1,
        2,2,2,2,2,
        2,2,1,1,1,
        1,1,1,1,1,
        1,1,1,1,1,
        1,1,1,1,1,
        1,1,1,1,1,
        1,1,1,1,1,
        1,1,1,1,1,
        1,1,1,1,1,
        1,1,1,1,2,
        2,1,1,1,1,
        1,1,1,1,1,
        1,1,1,1,1,
        1,1,1,1,1,
        1,2,1,1,1,
        1,1,1,2,1,
        1,1,1,2,2,
        2,2,2,1,1,
        1,1,1,1,1,
        1,1,1,1,1,
        1,1,1,1,1,
        1,2,2
    };
    public int index;

    //public GameObject EmptyObj;
    public GameObject Bullet;
    // Start is called before the first frame update

    public Vector3 BulletDir;
    public float BulletSpeed;
    public float RotateSpeed;
    void Start()
    {
        Timer = -0.25f;
        index = 0;
        BulletDir = new Vector3(-1, 0, 0);
        //初始状态隐藏机关
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Timer);
        DirRotate();
        if (isBulletReady())
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            shoot(bulletType[index - 1]);
        }
        
        //设置机关显示和隐藏的时间
        if ((Timer > 40f && Timer < 69f) || (Timer > 77f && Timer < 109f) || Timer > 122f)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        if ((Timer >= 69f && Timer <= 77f) || ((Timer >= 109f && Timer <= 122f)))
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

    public void shoot(int type)
    {
        switch (type)
        {
            case 1:
                {
                    GameObject bullet = Instantiate(Bullet);
                    bullet.transform.position = this.transform.position;
                    //赋初始力
                    bullet.GetComponent<noGravityBullet>().bulletDir = BulletDir;
                    bullet.GetComponent<noGravityBullet>().bulletSpeed = BulletSpeed;
                    //确定子弹位置
                    break;
                }

            case 2:
                {
                    Vector3 bulletdir = new Vector3(-1, 0, 0);
                    for(int i = 0; i < 8; i++)
                    {
                        GameObject bullet = Instantiate(Bullet);
                        bullet.transform.position = this.transform.position;
                        //赋初始力
                        bullet.GetComponent<noGravityBullet>().bulletDir = bulletdir;
                        bullet.GetComponent<noGravityBullet>().bulletSpeed = BulletSpeed;
                        //确定子弹位置
                        bulletdir = Quaternion.Euler(0, 0, 45) * bulletdir;
                    }
                    break;
                }
        }
    }

    public void DirRotate()
    {
        BulletDir = Quaternion.Euler(0, 0, RotateSpeed*Time.deltaTime)* BulletDir;
    }
}
