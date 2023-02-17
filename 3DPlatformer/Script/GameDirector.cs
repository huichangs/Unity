using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public float score = 1000.0f;
    public float resultScore = 0.0f;
    public float coin = 0f;
    public float flag = 0f;
    float remainCoin;

    GameObject scoreText;
    GameObject coinText;
    GameObject stageText;
    GameObject gameClearText;
    GameObject resultScoreText;
    GameObject resultCoinText;
    GameObject remainCoinText;
    GameObject scoreLoc;
    GameObject coinLoc;
    GameObject stageLoc;


    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GameObject.Find("Score");
        this.coinText = GameObject.Find("CoinScore");
        this.stageText = GameObject.Find("Stage");
        this.scoreLoc = GameObject.Find("ScoreLoc");
        this.coinLoc = GameObject.Find("CoinLoc");
        this.stageLoc = GameObject.Find("StageLoc");
        this.gameClearText = GameObject.Find("GameClear");
        this.resultScoreText = GameObject.Find("ResultScore");
        this.resultCoinText = GameObject.Find("ResultCoin");
        this.remainCoinText = GameObject.Find("RemainCoin");
    }

    // Update is called once per frame
    void Update()
    {
        score -= Time.deltaTime;
        this.scoreText.GetComponent<Text>().text = score.ToString("F2");
        this.coinText.GetComponent<Text>().text = coin.ToString("F0");
        this.stageText.GetComponent<Text>().text = flag.ToString("F0");

      

    }

    public void addScore()
    {
        score += 100;
    }

    public void decreaseScore()
    {
        score -= 50;
    }

    public void addCoin()
    {
        coin += 1;
    }

    public void addFlag()
    {
        flag += 1;
        if(flag == 4)
        {
            this.scoreText.GetComponent<Text>().text = "";
            this.coinText.GetComponent<Text>().text = "";
            this.stageText.GetComponent<Text>().text = "";
            this.scoreLoc.GetComponent<Text>().text = "";
            this.coinLoc.GetComponent<Text>().text = "";
            this.stageLoc.GetComponent<Text>().text = "";
            remainCoin = 10 - coin;
            resultScore = score;

            this.gameClearText.GetComponent<Text>().text = "Game Clear!!";

            this.resultScoreText.GetComponent<Text>().text = "최종 스코어 : " + resultScore.ToString("F2");
            this.resultCoinText.GetComponent<Text>().text = "획득 코인 : " + coin.ToString("F0");
            this.remainCoinText.GetComponent<Text>().text = "남은 코인 : " + remainCoin.ToString("F0");
        }
    }

    public void addStageScore()
    {
        score += 1000;
    }

}
