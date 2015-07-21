using UnityEngine;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class Main : MonoBehaviour
{
	void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 300, 30), "Project Id: " + Application.cloudProjectId);
	}

	public void SendAnalyticsCustomEvent()
	{
		int totalPotions = 5;
		int totalCoins = 100;
		string weaponID = "Weapon_102";
		Analytics.CustomEvent("gameOver", new Dictionary<string, object>
		{
			{ "potions", totalPotions },
			{ "coins", totalCoins },
			{ "activeWeapon", weaponID }
		});
	}
}
