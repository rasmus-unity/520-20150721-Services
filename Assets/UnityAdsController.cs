using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsController : MonoBehaviour
{
	private const string stagingUrl = "https://impact.staging.applifier.com/mobile/campaigns";

#if UNITY_IOS
	private const string GameId = "10346";
#else
	private const string GameId = "56224";
#endif

	private const string alternativeAdZoneId = "myTestAdPlacement";

	public void Start()
	{
		if (Advertisement.isInitialized)
		{
			Log (0, "Ads initialized");
		}
		else
		{
			InitializeAds();
		}
	}

	public void InitializeAds()
	{
		// Advertisement.SetCampaignDataURL("http://127.0.0.1:3500/mobile/campaigns");
		if (!Advertisement.isSupported)
		{
			Log(0, "Not supported!");
		}
		else
		{
			Log(0, "Initializing ads for staging");
			Advertisement.SetCampaignDataURL(stagingUrl);
			Advertisement.Initialize(GameId, false);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		// Log(1, string.Format("Ad showing: {0}", Advertisement.isShowing));
	}

	public void ShowAd()
	{
		ShowAd (null);
	}

	public void ShowAd(string zoneId)
	{
		if (!Advertisement.isInitialized)
		{
			Log(0, "Not initialized!");
			return;
		}

		if (!Advertisement.IsReady(zoneId))
		{
			if (zoneId != null)
			{
				Log(0, string.Format("Not ready (zone '{0}')!", zoneId));
			}
			else
			{
				Log(0, "Not ready!");
			}
			return;
		}

		var options = new ShowOptions
		{
			resultCallback = result => Log(0, string.Format("Result: {0}", result))
		};

		Advertisement.Show(zoneId, options);
	}

	public void ShowAlternativeAd()
	{
		ShowAd(alternativeAdZoneId);
	}

	public void ShowNonExistingZoneAd()
	{
		ShowAd("NonExistingZone");
	}

	public void Quit()
	{
		Application.Quit();
	}

	private void Log(int id, string text)
	{
		string textWithTime = string.Format("{0:HH:mm:ss} - {1}", System.DateTime.Now, text);
		Debug.LogFormat("=== {0} ===", textWithTime);
	}
}
