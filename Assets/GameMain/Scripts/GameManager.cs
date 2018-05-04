using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

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
	void Start () {
		MessageBroker.Default.Receive<ScoreBlockHit>().Subscribe(_ => {
			Score++;
			scoreText.text = Score + "pt";
		});
		Status = GameStatus.PLAY;
	}
	
	// Update is called once per frame
	void Update () {
		switch(Status){
			case GameStatus.PLAY:
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
