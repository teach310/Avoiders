using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class GameManager : MonoBehaviour {
	public enum GameStatus{
		START,
		PLAY,
		GAMEOVER,
		PAUSE
	}
	private GameStatus Status;
	public Text scoreText;
	public GameObject gameOverPanel;
	public GameObject startPanel;
	public int Score { get; private set; }
	void Start () {
		MessageBroker.Default.Receive<ScoreBlockHit>().Subscribe(_ => {
			Score++;
			scoreText.text = Score + "pt";
		});
		Status = GameStatus.START;
	}
	
	// Update is called once per frame
	void Update () {
		switch(Status){
			case GameStatus.START:
				break;
			case GameStatus.PLAY:
				break;
			case GameStatus.GAMEOVER:
				break;
			case GameStatus.PAUSE:
				break;
		}
	}

	public void GameStart(){
		startPanel.SetActive(false);
		Status = GameStatus.PLAY;
	}

	void GameOver(){
		gameOverPanel.SetActive(true);
	}
}
