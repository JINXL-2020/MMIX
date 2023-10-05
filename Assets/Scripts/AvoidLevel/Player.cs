using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP;    //HP = GameController.gameScore;
    public int HPReduceSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlayerControl()
    {

    }

    public void isAttacked()
    {
        //HP -= HPReduceSpeed;

        //Debug.Log("bulletbulletbullet");
        GameController.gameScore -= HPReduceSpeed;
        GameController.UpdateScoreLabel();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Åöµ½×Óµ¯ÔòµôÑª
        if (collision.gameObject.tag == "bullet")
        {
            isAttacked();
        }
    }

}
