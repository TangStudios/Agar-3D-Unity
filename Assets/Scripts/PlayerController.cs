using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text scoreText;
	public GameObject camera;

	private Rigidbody rb;
	private int score;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		scoreText.text = "SCORE: 0";
		score = 0;
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Food")){
			other.gameObject.SetActive(false);
			transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
			score++;
			scoreText.text = "SCORE: " + score.ToString();
			speed-=0.25f;
			if (speed == 0) {
				speed = 0.25f;
			}
		
			/*Vector3 tempPos = camera.transform.position;
			tempPos.y += 1f * Time.deltaTime;
			camera.transform.position = tempPos;*/
		}
	}
}
