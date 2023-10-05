using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSliderControl : MonoBehaviour
{
    private float posY;
    private float posX;
    private int lastScore;
    // Start is called before the first frame update
    void Start()
    {
        posY = GetComponent<RectTransform>().anchoredPosition.y;
        lastScore = GameController.gameScore;
    }

    // Update is called once per frame
    void Update()
    {
        posX = GetComponent<RectTransform>().anchoredPosition.x;
        //�����仯ʱ����λ����Ϣ
        if(GameController.gameScore != lastScore)
        {
            //�������� �� δ�������Ҷ�
            if (GameController.gameScore > lastScore && posX < 255f)
                GetComponent<RectTransform>().anchoredPosition = new Vector2(posX + (GameController.gameScore- lastScore) / 100, posY);
            //������С �� δ���������
            else if (GameController.gameScore < lastScore && posX > -255f)
                GetComponent<RectTransform>().anchoredPosition = new Vector2(posX - (lastScore-GameController.gameScore) / 100, posY);
            lastScore = GameController.gameScore;
        }
    }
}
