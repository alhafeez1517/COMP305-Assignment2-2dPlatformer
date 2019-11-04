using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Util
{
    [System.Serializable]
    public class UiController : MonoBehaviour
    {
        public Text cherryLabel;
        public Text livesLabel;
        private int _cherryScore;
        private int _lives;
        public Text gameOverLabel;
        public Text gameTitle;
        public Text winTitle;
        public GameObject restartButton;
        public GameObject startButton;
        public GameObject retryButton;
        public GameObject quitButton;
        public Image cherryImage;
        public Image livesImage;

        public AudioSource gameOverSfx;
        public AudioSource clickSfx;
        public AudioSource winSfx;

        public int CherryScore
        {
            get
            {
                return _cherryScore;
            }
            set
            {
                _cherryScore = value;

                cherryLabel.text = "X" + _cherryScore.ToString();
            }
        }

        public int Lives
        {
            get
            {
                return _lives;
            }
            set
            {
                _lives = value;

                if (_lives <= 0)
                {
                    SceneManager.LoadScene("End");
                    
                }
               
                livesLabel.text = "X" + _lives.ToString();
            }
        }

        private void Start()
        {

            switch (SceneManager.GetActiveScene().name)
            {
                case "End":

                    gameOverLabel.enabled = true;
                    restartButton.SetActive(true);
                    gameTitle.enabled = false;
                    cherryImage.enabled = false;
                    livesImage.enabled = false;
                    startButton.SetActive(false);
                    retryButton.SetActive(false);
                    quitButton.SetActive(false);
                    winTitle.enabled = false;
                    gameOverSfx.Play();


                    break;

                case "Main":
                    gameOverLabel.enabled = false;
                    gameTitle.enabled = false;
                    cherryImage.enabled = true;
                    livesImage.enabled = true;
                    restartButton.SetActive(false);
                    startButton.SetActive(false);
                    retryButton.SetActive(false);
                    quitButton.SetActive(false);
                    winTitle.enabled = false;

                    break;

                case "Start":
                    gameOverLabel.enabled = false;
                    gameTitle.enabled = true;
                    cherryImage.enabled = false;
                    livesImage.enabled = false;
                    restartButton.SetActive(false);
                    startButton.SetActive(true);
                    retryButton.SetActive(false);
                    quitButton.SetActive(false);
                    winTitle.enabled = false;
                    break;

                case "Win":

                    winSfx.Play();
                    gameOverLabel.enabled = false;
                    restartButton.SetActive(false);
                    gameTitle.enabled = false;
                    cherryImage.enabled = false;
                    livesImage.enabled = false;
                    startButton.SetActive(false);
                    retryButton.SetActive(true);
                    quitButton.SetActive(true);
                    winTitle.enabled = true;
                   
                    break;


            }
        }

        public void OnRestartButtonClick()
        {
            SceneManager.LoadScene("Main");
            clickSfx.Play();
           
        }

        public void OnStartButtonClick()
        {
            SceneManager.LoadScene("Main");
            clickSfx.Play();

        }

        public void OnRetryButtonClick()
        {
            SceneManager.LoadScene("Main");
            clickSfx.Play();
        }

        public void OnQuitButtonClick()
        {
            //SceneManager.LoadScene("Win");

            clickSfx.Play();
            Application.Quit();
        }




    }
}

