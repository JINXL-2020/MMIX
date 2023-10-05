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

        Vector3 mouse = Input.mousePosition;//��������Ļ����
        mouse.z = 10;//����zֵ���൱���������֮��ľ��룩
        Vector3 worldmouse = Camera.main.ScreenToWorldPoint(mouse);//�����Ļ����������

        //if (Input.GetMouseButtonDown(0))//����������Ҽ�
        //{
        //    GameObject a = Instantiate(AerialFloor);
        //    a.transform.position = worldmouse;//�������������=�����������
        //}
    }

    private void OnMouseOver()
    {
        Vector3 mouse = Input.mousePosition;//��������Ļ����
        mouse.z = 10;//����zֵ���൱���������֮��ľ��룩
        Vector3 worldmouse = Camera.main.ScreenToWorldPoint(mouse);//�����Ļ����������

        Player.transform.position = worldmouse;//�������������=�����������
    }
}
