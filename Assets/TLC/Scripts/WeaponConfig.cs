﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponConfig : MonoBehaviour {

	public string Name;
	public int Number;
	public int Price;
	public Text Header;
	public GameObject Preco;
	public GameObject BotaoComprar;
	public GameObject BotaoSelecionar;
	public GameObject PopUpError;

	public void comprar ()
	{
		if (SaveSystem.current.polys >= Price) 
		{
			SaveSystem.current.polys -= Price;

			SaveSystem.current.weaponsOwned [Number] = true;

			SaveSystem.Save ();
		} 
		else
		{
			PopUpError.SetActive (true);
		}
	}

	public void equipar()
	{
		SaveSystem.current.selectedWeapon = Number;

		SaveSystem.Save ();
	}

	void Start()
	{
		Header.text = Name;
		Preco.GetComponentInChildren<Text> ().text = Price.ToString();
	}

	void Update () 
	{
		if (SaveSystem.current.weaponsOwned [Number]) 
		{
			if (BotaoComprar.activeSelf) 
			{
				BotaoComprar.SetActive (false);
			}
			if (!BotaoSelecionar.activeSelf)
			{
				BotaoSelecionar.SetActive (true);
			}
			if (Preco.activeSelf) 
			{
				Preco.SetActive (false);
			}

			if (SaveSystem.current.selectedWeapon == Number) 
			{
				BotaoSelecionar.GetComponent<Button> ().interactable = false;
				BotaoSelecionar.GetComponentInChildren<Text> ().text = "SELECTED";
			}
			else 
			{
				BotaoSelecionar.GetComponent<Button> ().interactable = true;
				BotaoSelecionar.GetComponentInChildren<Text> ().text = "SELECT";
			}
		}
		else
		{
			if (!BotaoComprar.activeSelf) 
			{
				BotaoComprar.SetActive (true);
			}
			if (BotaoSelecionar.activeSelf)
			{
				BotaoSelecionar.SetActive (false);
			}
			if (!Preco.activeSelf) 
			{
				Preco.SetActive (true);
			}
		}
	}
}
