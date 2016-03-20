using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public Boundry boundry;

	public float speed;
	public float tilt;
	public float fireRate;

	private float nextFire;

	public GameObject shot;

	public Transform shotSpawn;

	private Rigidbody rb;

	private AudioSource audioSource ;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		if ((Input.GetButton("Fire1") || Input.GetKeyDown("space")) && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;

			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

			audioSource.Play();
		}
	}
	 
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal , 0.0f, moveVertical);

		rb.velocity = movement * speed;

		rb.position = new Vector3
		(
			Mathf.Clamp(rb.position.x, boundry.xMin, boundry.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z, boundry.zMin, boundry.zMax)
		);

		rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}

[System.Serializable]
public class Boundry
{
	public float xMin, xMax, zMin, zMax;
}
