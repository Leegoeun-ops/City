using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public GameObject gameOverText;
    public GameObject playerGameObject;
    public Text hpText;
    public Text scoreText;
    public int score;
    public bool isGameOver;

    //MovementProvider2 moveProvider;
   
    void Start()
    {
        score = 0;
        isGameOver = false;
        //moveProvider = GetComponent<MovementProvider2>();
        //GameObject.Find("Training table").transform.Find("SecondMask").gameObject.SetActive(true);
    }
    void Update()
    {
        if(!isGameOver)
        {
            //hpText.text = "HP :" + (int)playerGameObject.GetComponent<PlayerController>().hp;
            //scoreText.text = "Score :" + (int)score;
        }
    }
    //public void StartGame()
    //{
    //    moveProvider.StartMove();
    //}

    public void EndGame()
    {
        //isGameOver = true;
        //hpText.text = "HP : 0";
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Scene2");
    }

}
