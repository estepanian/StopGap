using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public Text restartText;
    public Text yrot;
    public Text blockCountText;

    public GameObject sky;
    public GameObject guy;

    public int blockCount;
    // Start is called before the first frame update
    void Start()
    {
        CleanUI();
        Time.timeScale = 1;
        scoreText.text = "Touch to make blocks.";
        restartText.enabled = false;
        yrot.enabled = false;
        blockCount = 0;
        blockCountText.text = blockCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the background
        Vector3 guyP = guy.transform.position;
        Vector3 newSkyP = sky.transform.position;
        newSkyP.z = guyP.z;
        sky.transform.position = newSkyP;

        if ((guyP.z < -10)&& scoreText.enabled){
            scoreText.text = "";
            scoreText.enabled = false;
        }
    }
    public void GameOver(){
        scoreText.enabled = true;
        restartText.enabled = true;
        Time.timeScale = 0;
        enabled = false;
        scoreText.text = ((-guy.transform.position.z) - 2).ToString() + " meters";
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
    public void AddNibble(){
        blockCount += 1;
        blockCountText.text = blockCount.ToString();
    }
    public void RemoveNibble(){
        blockCount -= 1;
        blockCountText.text = blockCount.ToString();
    }
    public void OOM(){
        //In here, maybe make the blockCount text flash or something.
    }
}
