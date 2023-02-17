using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameDirector : MonoBehaviour
{
    GameObject hp;
    GameObject scoreText;
    GameObject gameClearText;
    GameObject resultScoreText;
    public float score = 1000.0f;
    bool die;
    public float resultScore;
    // Start is called before the first frame update
    void Start()
    {
        this.hp = GameObject.Find("hp");
        this.scoreText = GameObject.Find("score");
        this.gameClearText = GameObject.Find("gameClear");
        this.resultScoreText = GameObject.Find("resultScore");

    }

    // Update is called once per frame
    void Update()
    {
        score -= Time.deltaTime;
        this.scoreText.GetComponent<Text>().text = "점수 : " + score.ToString("F2");
    }

    public void decreaseHp()
    {
        this.hp.GetComponent<Image>().fillAmount -= 0.1f;
    }

    public void increaseHp()
    {
        this.hp.GetComponent<Image>().fillAmount += 0.1f;
    }
    
    public void addScore()
    {
        score += 100;
    }

    public void addScore2()
    {
        score += 1000;
    }

    public void isGameClearText()
    {
        this.gameClearText.GetComponent<Text>().text = "Game Clear";
    }

    public bool isDie()
    {
        die = false;
        if(this.hp.GetComponent<Image>().fillAmount == 0)
        {
            die = true;
        }

        return die;
    }

    public void result()
    {
        resultScore = score;
        this.resultScoreText.GetComponent<Text>().text = "당신의 점수 : " + resultScore.ToString("F2");
    }

}
