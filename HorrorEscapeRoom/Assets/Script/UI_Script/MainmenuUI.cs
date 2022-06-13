using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainmenuUI : MonoBehaviour
{
	public Image Obvod, Obvod2;
	public LoadScene _LoadScene;
	public GameObject MenuParentObject, FoneLoad, LoadParentObject, OptionsParentObject, CreditsParentObject, SaveLoadParentObject;
	public Slider SliderSound, SliderGraph, SliderResolut;
	// Use this for initialization
	void Start()
	{

		AudioListener.volume = PlayerPrefs.GetFloat("SliderSound");
		QualitySettings.SetQualityLevel(System.Convert.ToInt32(PlayerPrefs.GetFloat("SliderGraph") + 1));
		if (PlayerPrefs.GetFloat("SliderResolut") == 0)
		{
			Screen.SetResolution(800, 600, true);
		}
		if (PlayerPrefs.GetFloat("SliderResolut") == 1)
		{
			Screen.SetResolution(1280, 720, true);
		}
		if (PlayerPrefs.GetFloat("SliderResolut") == 2)
		{
			Screen.SetResolution(1600, 1900, true);
		}
		if (PlayerPrefs.GetFloat("SliderResolut") == 3)
		{
			Screen.SetResolution(1920, 1080, true);
		}
	}

	// Update is called once per frame
	void Update()
	{
	}

	public void OnLoadLevel()
	{
		MenuParentObject.SetActive(false);
		SaveLoadParentObject.SetActive(false);
		CreditsParentObject.SetActive(false);
		OptionsParentObject.SetActive(false);
		MenuParentObject.SetActive(false);
		LoadParentObject.SetActive(true);
		FoneLoad.SetActive(true);
		_LoadScene.isLoading = true;
		PlayerPrefs.SetInt("Load", 0);
		_LoadScene.StartCoroutine("_Start");
	}
	public void OnOptions()
	{
		MenuParentObject.SetActive(false);
		OptionsParentObject.SetActive(true);
	}
	public void OnCredits()
	{
		MenuParentObject.SetActive(false);
		CreditsParentObject.SetActive(true);
	}
	public void OnExit()
	{
		Application.Quit();
	}
	public void OnExitCredits()
	{
		Obvod.rectTransform.anchoredPosition = new Vector2(0, 0);
		CreditsParentObject.SetActive(false);
		MenuParentObject.SetActive(true);
	}
	public void SaveOptions()
	{
		Obvod.rectTransform.anchoredPosition = new Vector2(0, 0);
		PlayerPrefs.SetFloat("SliderSound", SliderSound.value);
		PlayerPrefs.SetFloat("SliderGraph", SliderGraph.value);
		PlayerPrefs.SetFloat("SliderResolut", SliderResolut.value);
		AudioListener.volume = PlayerPrefs.GetFloat("SliderSound");
		QualitySettings.SetQualityLevel(System.Convert.ToInt32(PlayerPrefs.GetFloat("SliderGraph") + 1));
		if (PlayerPrefs.GetFloat("SliderResolut") == 0)
		{
			Screen.SetResolution(800, 600, true);
		}
		if (PlayerPrefs.GetFloat("SliderResolut") == 1)
		{
			Screen.SetResolution(1280, 720, true);
		}
		if (PlayerPrefs.GetFloat("SliderResolut") == 2)
		{
			Screen.SetResolution(1600, 1900, true);
		}
		if (PlayerPrefs.GetFloat("SliderResolut") == 3)
		{
			Screen.SetResolution(1920, 1080, true);
		}
		OptionsParentObject.SetActive(false);
		MenuParentObject.SetActive(true);
	}

	public void OnObvodka(Text _text)
	{
		Obvod.rectTransform.anchoredPosition = new Vector2(_text.rectTransform.anchoredPosition.x, _text.rectTransform.anchoredPosition.y);
	}
	public void OnSaveLoad()
	{
		MenuParentObject.SetActive(false);
		SaveLoadParentObject.SetActive(true);
	}
	public void ExitSaveLoad()
	{
		SaveLoadParentObject.SetActive(false);
		MenuParentObject.SetActive(true);
	}
	public void OnLoadGame(int num)
	{
		if (PlayerPrefs.GetInt("Saved" + System.Convert.ToString(num)) != 0)
		{
			MenuParentObject.SetActive(false);
			SaveLoadParentObject.SetActive(false);
			CreditsParentObject.SetActive(false);
			OptionsParentObject.SetActive(false);
			PlayerPrefs.SetInt("Load", 1);
			PlayerPrefs.SetInt("NmSav", num);
			MenuParentObject.SetActive(false);
			LoadParentObject.SetActive(true);
			FoneLoad.SetActive(true);
			_LoadScene.isLoading = true;

			_LoadScene.StartCoroutine("_Start");
		}
	}
}
