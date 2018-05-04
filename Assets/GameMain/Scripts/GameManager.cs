using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

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
	[SerializeField] WallSpawner wallSpawner;
	[SerializeField] PlayerCore playerCore;
	public int Score { get; private set; }
	void Start () {
		playerCore.RightBallGameObj.OnCollisionEnterAsObservable().Where(x => x.gameObject.tag == "Block").Subscribe(_=> GameOver());
		playerCore.LeftBallGameObj.OnCollisionEnterAsObservable().Where(x => x.gameObject.tag == "Block").Subscribe(_=> GameOver());
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
		wallSpawner.GameStart();
	}

	void GameOver(){
		gameOverPanel.SetActive(true);
		Time.timeScale = 0f;		
	}
}
