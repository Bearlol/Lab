using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static bool _isLoaded;
	int _score;
	public GameObject playerPrefab;
	static GameObject playerReference;
	public GameObject Screen_Title;
	public GameObject LevelSelect;
	public AudioClip TitleScreen;
	public AudioClip levelSelect;

	// Use this for initialization
	void Start () {
		//Screen_HUD.GetComponent<CanvasGroup>().alpha = 0;

		Screen_Title.SetActive (true);
		SoundManager.instance.PlayMusic (TitleScreen);

		if (isLoaded) {
			DestroyImmediate (gameObject);
		} else {
			isLoaded = true;
			DontDestroyOnLoad (gameObject);
			playerReference = playerPrefab;
			Screen_Title.SetActive (true);
			LevelSelect.SetActive (false);

		}

	}
	
	// Update is called once per frame
	void Update () { 

		if (Input.GetKeyDown (KeyCode.Escape)) 
			Screen_Title.SetActive (true);
			


	}

	public void StartGame()
	{
		Application.LoadLevel("Level");
		Screen_Title.SetActive (false);
		LevelSelect.SetActive(false);

	}
	public void StartLevel(){
		Screen_Title.SetActive(false);
		LevelSelect.SetActive(true);
		SoundManager.instance.PlayMusic (levelSelect);
	}

	public static void SpawnPlayer()
	{
		string spawnPoint = "spawnPoint" + Application.loadedLevel;
		
		Transform spawnPointTransform = GameObject.Find(spawnPoint).GetComponent<Transform>();
		
		Instantiate(playerReference,spawnPointTransform.position, Quaternion.identity);
	}

	public static bool isLoaded
	{
		get
		{
			return _isLoaded;
		}

		set
		{
			_isLoaded = value;
		}
	}

}
