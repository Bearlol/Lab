using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public Rigidbody2D rb;	// Need to drag object into inspector
	public Animator anim;
	
	public bool facingRight;// Sprite is facing right
	public bool isGrounded;
	public float jumpForce;	// How much force to add to character
	//public float jumpForce;	// How much force to add to character
	public GameObject projectile;
	public Transform projectileSpawnPoint;
	public Collider2D player;
	public AudioClip fireClip;
	public AudioClip deathClip;
	Rigidbody2D temp;
	public AudioClip quickMan;
	public AudioClip hitClip;
	public AudioClip health;
	public AudioClip life;
	public AudioClip energy;
	public AudioClip land;
	bool hit = false;




	void Start () {
		SoundManager.instance.PlayMusic (quickMan);
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		
		if (!rb)
			Debug.Log ("No Rigidbody2D Attached");
		// Use this for initialization
		if (!rb)
			Debug.Log ("No Rigidbody2D Attached. Drag Object into Inspector.");
		
		if (!anim)
			Debug.Log ("No Animator Attached. Drag Object into Inspector.");
	}
	
	// Update is called once per frame

	void Update () {



		float move = Input.GetAxisRaw ("Horizontal");
		rb.velocity = new Vector2 (move, rb.velocity.y);		
		anim.SetFloat ("Move", Mathf.Abs(move));
		
		if ((move < 0 && facingRight) 
		    || (move > 0 && !facingRight) ) {
			flip();
		}
		if(Input.GetKey(KeyCode.S) && isGrounded && Input.GetKey(KeyCode.Space)){
			
			anim.SetFloat ("Slide", 1);
			if (facingRight)
				rb.velocity = new Vector2 (1.5f,0);
			else
				rb.velocity = new Vector2(-1.5f,0);
			
			
			
		}
		else if (Input.GetKeyDown (KeyCode.Space)) {
			
			if(isGrounded)
			{
					
					rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
					isGrounded = false;
					Debug.Log(rb.velocity);

				
			}
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			anim.SetFloat ("Slide", 0);

		}
		if (!isGrounded) {
			anim.SetFloat ("Slide", 0);

			}

		if (Input.GetButtonDown("Fire1")){

			anim.SetFloat ("FIRE",1);
			GameObject pTemp = Instantiate(projectile,projectileSpawnPoint.position,projectileSpawnPoint.rotation) as GameObject;
			Physics2D.IgnoreCollision(player,pTemp.GetComponent<Collider2D>());
			temp = pTemp.GetComponent<Rigidbody2D>();
			pTemp.SetActive(true);
			if (facingRight)
			temp.velocity = new Vector2 (1.4f, 0);
			else
			temp.velocity = new Vector2 (-1.4f, 0);

			SoundManager.instance.PlaySingle(fireClip);
		

		}
		if (Input.GetButtonUp ("Fire1")){
		    anim.SetFloat ("FIRE",0);
		}




	}
	

		
	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "Enemy") {
			if (hit == false){
				hit = true;
				SoundManager.instance.PlaySingle (hitClip);	
				anim.SetInteger ("Hit", 1);
				StartCoroutine (topo ());
				hit = false;
				anim.SetInteger ("Hit", 0);
			}
		}
	}
	
	void OnCollisionExit2D(Collision2D c)
	{
		Debug.Log ("Collision Exit");
	}
	
	void OnCollisionStay2D(Collision2D c)
	{
		Debug.Log ("Collision Stay");
		
	}
	
	void OnTriggerEnter2D(Collider2D c)
	{	
		if (c.gameObject.tag == "Collectible") {
			SoundManager.instance.PlaySingle (energy);
			//c.gameObject.SetActive(false);
			Destroy (c.gameObject);	// Destroy instantly
			//Destroy(c.gameObject,1);// Destror after 1s
		}
		if (c.gameObject.tag == "Life") {
			SoundManager.instance.PlaySingle (life);
			//c.gameObject.SetActive(false);
			Destroy (c.gameObject);	// Destroy instantly
			//Destroy(c.gameObject,1);// Destror after 1s
		}
		if (c.gameObject.tag == "Health") {
			SoundManager.instance.PlaySingle (health);
			//c.gameObject.SetActive(false);
			Destroy (c.gameObject);	// Destroy instantly
			//Destroy(c.gameObject,1);// Destror after 1s
		}
		if (c.gameObject.tag == "LevelFloor") {
			anim.SetFloat ("jumping", 0);
			isGrounded = true;
		}

		if (c.gameObject.tag == "Death") {

			SoundManager.instance.PlaySingle (deathClip);
			Application.LoadLevel("Screen_Title");
		}

		if (c.gameObject.tag == "Enemy") {
			if (hit == false){
				hit = true;
				SoundManager.instance.PlaySingle (hitClip);	
				anim.SetInteger ("Hit", 1);
				StartCoroutine (topo ());
				hit = false;
				anim.SetInteger ("Hit", 0);
				}
			}
		}

	void OnTriggerExit2D(Collider2D c){
		if (c.gameObject.tag == "LevelFloor") {
			anim.SetFloat ("jumping", 1);
			isGrounded = false;
			if (anim.GetFloat ("Slide") > 0) {

			}


			if (Input.GetButtonDown ("Fire1")) {
				Debug.Log ("Attack");
				anim.SetFloat ("FIRE", 1);
			}

			if (Input.GetButtonUp ("Fire1")) {
				anim.SetFloat ("FIRE", 0);
			}

		}

	}		
		

	IEnumerator topo() {

		yield return new WaitForSeconds(2.0f);

	}

	void flip()
	{
		facingRight = !facingRight;
		
		Vector3 scaleFactor = transform.localScale;
		
		scaleFactor.x *= -1;
		
		transform.localScale = scaleFactor;
	}
	
}


