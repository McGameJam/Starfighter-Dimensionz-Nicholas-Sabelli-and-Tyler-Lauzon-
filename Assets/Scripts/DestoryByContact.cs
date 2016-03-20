using UnityEngine;
using System.Collections;

public class DestoryByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplotion;

	public int scoreValue;

	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");

		if(gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		else if(gameControllerObject == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag != "Boundary")
		{
//			Debug.Log(other.name);
			Instantiate(explosion, transform.position, transform.rotation);

			if(other.tag == "Player")
			{
				Instantiate(playerExplotion, other.transform.position, other.transform.rotation);
				gameController.GameOver();
			}

			gameController.AddScore(scoreValue);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
