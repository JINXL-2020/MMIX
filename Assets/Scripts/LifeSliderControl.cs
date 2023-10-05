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
        //分数变化时更新位置信息
        if(GameController.gameScore != lastScore)
        {
            //分数增加 且 未到达最右端
            if (GameController.gameScore > lastScore && posX < 255f)
                GetComponent<RectTransform>().anchoredPosition = new Vector2(posX + (GameController.gameScore- lastScore) / 100, posY);
            //分数减小 且 未到达最左端
            else if (GameController.gameScore < lastScore && posX > -255f)
                GetComponent<RectTransform>().anchoredPosition = new Vector2(posX - (lastScore-GameController.gameScore) / 100, posY);
            lastScore = GameController.gameScore;
        }
    }
}
