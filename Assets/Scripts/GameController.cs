using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int i;
    public Text scoreText;
    public Text restartText;
    // Start is called before the first frame update
    void Start()
    {
        CleanUI();
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //Ends the game if you fall through
        i += 1;
        GameObject go = GameObject.Find("Guy");
        if(go.transform.position.y < -5){
            GameOver(i);
        }
    }
    public void GameOver(int score){
        enabled = false;
        scoreText.text = score.ToString();
        restartText.text = "Click to Restart";

    }
    public void RestartGame(){
        CleanUI();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    private void CleanUI(){
        scoreText.text = "";
        restartText.text = "";
    }
}
