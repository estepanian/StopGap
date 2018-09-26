using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int score;
    public Text scoreText;
    public Text restartText;
    public Text yrot;

    public GameObject sky;
    public GameObject guy;
    // Start is called before the first frame update
    void Start()
    {
        CleanUI();
        score = 0;
        Time.timeScale = 1;
        scoreText.enabled = false;
        restartText.enabled = false;
        yrot.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        //durr durr score
        score += 1;

        //Moves the background
        Vector3 guyP = guy.transform.position;
        Vector3 newSkyP = sky.transform.position;
        newSkyP.z = guyP.z;
        sky.transform.position = newSkyP;
    }
    public void GameOver(){
        scoreText.enabled = true;
        restartText.enabled = true;
        Time.timeScale = 0;
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
