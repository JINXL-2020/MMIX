using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noGravityBullet : MonoBehaviour
{
    public float ExistTimerLimit;
    public float Timer;
    public Vector3 bulletDir;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Timer = ExistTimerLimit;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Destroyer();
    }


    private void Destroyer()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0) Destroy(gameObject);
    }

    private void Move()
    {
        transform.Translate(bulletDir * bulletSpeed*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
