using UnityEngine;
using System.Collections;
using UnityEditor;

public class EnableAdvertisement
{
	[MenuItem("Ads/Status")]
	private static void AdsShowStatus()
	{
		if (UnityEditor.Advertisements.AdvertisementSettings.testMode)
		{
			Debug.Log(string.Format(
				"AdvertisementSettings.enabled: {0} (TestMode on)\nAdvertisementSettings.initializeOnStartup: {1}",
				UnityEditor.Advertisements.AdvertisementSettings.enabled,
				UnityEditor.Advertisements.AdvertisementSettings.initializeOnStartup));
			return;
		}

		Debug.Log(string.Format(
			"AdvertisementSettings.enabled: {0}\nAdvertisementSettings.initializeOnStartup: {1}", 
			UnityEditor.Advertisements.AdvertisementSettings.enabled,
			UnityEditor.Advertisements.AdvertisementSettings.initializeOnStartup));
	}

	[MenuItem("Ads/Enable")]
	private static void AdsEnable()
	{
		UnityEditor.Advertisements.AdvertisementSettings.enabled = true;
		UnityEditor.Advertisements.AdvertisementSettings.initializeOnStartup = true;
		
		AdsShowStatus();
	}

	[MenuItem("Ads/Enable for custom initialization")]
	private static void AdsEnableForCustom()
	{
		UnityEditor.Advertisements.AdvertisementSettings.enabled = true;
		UnityEditor.Advertisements.AdvertisementSettings.initializeOnStartup = false;

		AdsShowStatus();
	}

	[MenuItem("Ads/Disable")]
	private static void AdsDisable()
	{
		UnityEditor.Advertisements.AdvertisementSettings.enabled = false;
		UnityEditor.Advertisements.AdvertisementSettings.initializeOnStartup = false;
		
		AdsShowStatus();
	}
}
