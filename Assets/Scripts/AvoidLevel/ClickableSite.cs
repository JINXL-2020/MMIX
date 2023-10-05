using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableSite : MonoBehaviour
{
    public GameObject Player;
    //public GameObject AerialFloor;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

        Vector3 mouse = Input.mousePosition;//获得鼠标屏幕坐标
        mouse.z = 10;//设置z值（相当于与摄像机之间的距离）
        Vector3 worldmouse = Camera.main.ScreenToWorldPoint(mouse);//获得屏幕的世界坐标

        //if (Input.GetMouseButtonDown(0))//若点下鼠标右键
        //{
        //    GameObject a = Instantiate(AerialFloor);
        //    a.transform.position = worldmouse;//球体的世界坐标=鼠标世界坐标
        //}
    }

    private void OnMouseOver()
    {
        Vector3 mouse = Input.mousePosition;//获得鼠标屏幕坐标
        mouse.z = 10;//设置z值（相当于与摄像机之间的距离）
        Vector3 worldmouse = Camera.main.ScreenToWorldPoint(mouse);//获得屏幕的世界坐标

        Player.transform.position = worldmouse;//球体的世界坐标=鼠标世界坐标
    }
}
