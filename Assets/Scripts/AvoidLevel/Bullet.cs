using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float ExistTimerLimit;
    public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = ExistTimerLimit;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(0, -Time.deltaTime * 1.0f * speed, 0));
        Destroyer();
    }


    private void Destroyer()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
