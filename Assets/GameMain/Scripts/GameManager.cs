using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public enum GameStatus{
		PLAY,
		GAMEOVER,
		PAUSE
	}
	private GameStatus Status;
	public Text scoreText;
	public GameObject gameOverPanel;
	public int Score { get; private set; }
	public void SetScore(){
		Score++;
	}
	void Start () {
		Status = GameStatus.PLAY;
	}
	
	// Update is called once per frame
	void Update () {
		switch(Status){
			case GameStatus.PLAY:
				scoreText.text = Score + "pt";
				break;
			case GameStatus.GAMEOVER:
				break;
			case GameStatus.PAUSE:
				break;
		}
	}

	void GameOver(){
		gameOverPanel.SetActive(true);
	}
}
