using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	public Image Obvod;
	public LoadScene _LoadScene;
	public GameObject MenuParentObject, FoneLoad, LoadParentObject, OptionsParentObject, CreditsParentObject;
	public Slider SliderSound;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	public void OnLoadLevel () {
		MenuParentObject.SetActive (false);
		CreditsParentObject.SetActive (false);
		OptionsParentObject.SetActive (false);
		MenuParentObject.SetActive (false);
		LoadParentObject.SetActive (true);
		FoneLoad.SetActive (true);
		_LoadScene.isLoading = true;
		PlayerPrefs.SetInt ("Load", 0);
		_LoadScene.StartCoroutine("_Start");
	}
	public void OnOptions() {
		MenuParentObject.SetActive (false);
		OptionsParentObject.SetActive (true);
	}
	public void OnCredits() {
		MenuParentObject.SetActive (false);
		CreditsParentObject.SetActive (true);
	}
	public void OnExit () {
		Application.Quit ();
	}
	public void OnExitCredits () {
		Obvod.rectTransform.anchoredPosition = new Vector2 (0, 0);
		CreditsParentObject.SetActive (false);
		MenuParentObject.SetActive (true);
	}
	public void SaveOptions () {
		Obvod.rectTransform.anchoredPosition = new Vector2 (0, 0);
		PlayerPrefs.SetFloat ("SliderSound", SliderSound.value);
		OptionsParentObject.SetActive (false);
		MenuParentObject.SetActive (true);
	}
	
	public void OnObvodka (Text _text) {
		Obvod.rectTransform.anchoredPosition = new Vector2 (_text.rectTransform.anchoredPosition.x, _text.rectTransform.anchoredPosition.y);
	}
	public void OnLoadGame () {
		MenuParentObject.SetActive(false);
		CreditsParentObject.SetActive(false);
		OptionsParentObject.SetActive(false);
		MenuParentObject.SetActive(false);
		LoadParentObject.SetActive(true);
		FoneLoad.SetActive(true);
		_LoadScene.isLoading = true;
		PlayerPrefs.SetInt("Load", 0);
		_LoadScene.StartCoroutine("_Start");
		//ES3AutoSaveMgr.Current.Load();
	}
}
