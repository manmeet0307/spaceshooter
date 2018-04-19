using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class GameStateManager : MonoBehaviour{






	public Text gameOverText;
	
	public Text scoreText;
	public Text HighScoreText;

	public bool GameOver{
		get{ return gameOver; }
		set{ gameOver = value; }
	}
	
	

	
	
	[SerializeField]
	private GameObject explosionPrefab;

	
	private int score;
	private bool gameOver;


	private void Start (){
		
			
		scoreText.text = "Score : 0";	
		HighScoreText.text = "HighScore : "+PlayerPrefs.GetInt("HighScore",0);
		
		gameOverText.enabled = false;

	
	}
	
	private void Update () {
			
			if (gameOver){


				gameOverText.enabled = true;
						


				StartCoroutine(DelayForGameStart());

			}
		
		
		
		
	}

	IEnumerator DelayForGameStart(){
		//update high score
		PlayerPrefs.SetInt("HighScore",Math.Max(score,PlayerPrefs.GetInt("HighScore")));		
		yield return new WaitForSeconds(8.0f);		
		SceneManager.LoadScene("StartScene");
		
	}

	

	public void updateScore(int addVal){
		score += addVal;
		scoreText.text = "Score : " + score;
	}

	public  GameObject GetExplosionPrefab(){
		return explosionPrefab;
		
	}
}
