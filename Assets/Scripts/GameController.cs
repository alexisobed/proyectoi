using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    public float parallaxSpeed = 0.02f;
    public RawImage Background;
    public RawImage Platform;
    public GameObject uiIdle;



    public enum GameState {Idle,Playing };
    public GameState gameState = GameState.Idle;


    public GameObject player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //empieza el juego
        if(gameState==GameState.Idle && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0)))
        {
            gameState = GameState.Playing;
            uiIdle.SetActive(false);
            player.SendMessage("UpdateState", "PlayerRun");

        }
        else if (gameState == GameState.Playing) {
            Parallax();
  }

 

    }

    void Parallax()
    {
        float finalSpeed = parallaxSpeed * Time.deltaTime;
        Background.uvRect = new Rect(Background.uvRect.x + finalSpeed, 0f, 1f, 1f);
        Platform.uvRect = new Rect(Platform.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);

    }
}
