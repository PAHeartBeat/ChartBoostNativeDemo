using System;
using UnityEngine;
using ChartboostSDK;

public class ChartboostExample: MonoBehaviour {

	public GameObject inPlayIcon;
	public GameObject inPlayText;
	
	private CBInPlay inPlayAd;

	void OnEnable() {
		// Listen to all impression-related events
		Chartboost.didFailToLoadInterstitial += didFailToLoadInterstitial;
		Chartboost.didDismissInterstitial += didDismissInterstitial;
		Chartboost.didCloseInterstitial += didCloseInterstitial;
		Chartboost.didClickInterstitial += didClickInterstitial;
		Chartboost.didCacheInterstitial += didCacheInterstitial;
		Chartboost.shouldDisplayInterstitial += shouldDisplayInterstitial;
		Chartboost.didDisplayInterstitial += didDisplayInterstitial;
		Chartboost.didFailToLoadMoreApps += didFailToLoadMoreApps;
		Chartboost.didDismissMoreApps += didDismissMoreApps;
		Chartboost.didCloseMoreApps += didCloseMoreApps;
		Chartboost.didClickMoreApps += didClickMoreApps;
		Chartboost.didCacheMoreApps += didCacheMoreApps;
		Chartboost.shouldDisplayMoreApps += shouldDisplayMoreApps;
		Chartboost.didDisplayMoreApps += didDisplayMoreApps;
		Chartboost.didFailToRecordClick += didFailToRecordClick;
		Chartboost.didFailToLoadRewardedVideo += didFailToLoadRewardedVideo;
		Chartboost.didDismissRewardedVideo += didDismissRewardedVideo;
		Chartboost.didCloseRewardedVideo += didCloseRewardedVideo;
		Chartboost.didClickRewardedVideo += didClickRewardedVideo;
		Chartboost.didCacheRewardedVideo += didCacheRewardedVideo;
		Chartboost.shouldDisplayRewardedVideo += shouldDisplayRewardedVideo;
		Chartboost.didCompleteRewardedVideo += didCompleteRewardedVideo;
		Chartboost.didDisplayRewardedVideo += didDisplayRewardedVideo;
		Chartboost.didCacheInPlay += didCacheInPlay;
		Chartboost.didFailToLoadInPlay += didFailToLoadInPlay;
		Chartboost.didPauseClickForConfirmation += didPauseClickForConfirmation;
		Chartboost.willDisplayVideo += willDisplayVideo;
		#if UNITY_IPHONE
		Chartboost.didCompleteAppStoreSheetFlow += didCompleteAppStoreSheetFlow;
		#endif
	}
	void OnDisable() {
		// Remove event handlers
		Chartboost.didFailToLoadInterstitial -= didFailToLoadInterstitial;
		Chartboost.didDismissInterstitial -= didDismissInterstitial;
		Chartboost.didCloseInterstitial -= didCloseInterstitial;
		Chartboost.didClickInterstitial -= didClickInterstitial;
		Chartboost.didCacheInterstitial -= didCacheInterstitial;
		Chartboost.shouldDisplayInterstitial -= shouldDisplayInterstitial;
		Chartboost.didDisplayInterstitial -= didDisplayInterstitial;
		Chartboost.didFailToLoadMoreApps -= didFailToLoadMoreApps;
		Chartboost.didDismissMoreApps -= didDismissMoreApps;
		Chartboost.didCloseMoreApps -= didCloseMoreApps;
		Chartboost.didClickMoreApps -= didClickMoreApps;
		Chartboost.didCacheMoreApps -= didCacheMoreApps;
		Chartboost.shouldDisplayMoreApps -= shouldDisplayMoreApps;
		Chartboost.didDisplayMoreApps -= didDisplayMoreApps;
		Chartboost.didFailToRecordClick -= didFailToRecordClick;
		Chartboost.didFailToLoadRewardedVideo -= didFailToLoadRewardedVideo;
		Chartboost.didDismissRewardedVideo -= didDismissRewardedVideo;
		Chartboost.didCloseRewardedVideo -= didCloseRewardedVideo;
		Chartboost.didClickRewardedVideo -= didClickRewardedVideo;
		Chartboost.didCacheRewardedVideo -= didCacheRewardedVideo;
		Chartboost.shouldDisplayRewardedVideo -= shouldDisplayRewardedVideo;
		Chartboost.didCompleteRewardedVideo -= didCompleteRewardedVideo;
		Chartboost.didDisplayRewardedVideo -= didDisplayRewardedVideo;
		Chartboost.didCacheInPlay -= didCacheInPlay;
		Chartboost.didFailToLoadInPlay -= didFailToLoadInPlay;
		Chartboost.didPauseClickForConfirmation -= didPauseClickForConfirmation;
		Chartboost.willDisplayVideo -= willDisplayVideo;
		#if UNITY_IPHONE
		Chartboost.didCompleteAppStoreSheetFlow -= didCompleteAppStoreSheetFlow;
		#endif
	}

	void Update() {
		#if TESTMODE_CHARTBOOST
		if(Input.touchCount > 0 && inPlayIcon.guiTexture.HitTest(Input.GetTouch(0).position) && Input.GetTouch(0).phase == TouchPhase.Began) {
			inPlayAd.click();
		}
		#endif
	}

	void OnGUI() {
		#if TESTMODE_CHARTBOOST
		/*
		#if UNITY_ANDROID
		// Disable user input for GUI when impressions are visible
		// This is only necessary on Android if we have disabled impression activities
		//   by having called CBBinding.init(ID, SIG, false), as that allows touch
		//   events to leak through Chartboost impressions
		GUI.enabled = !Chartboost.isImpressionVisible();
		#endif
		*/
		GUI.matrix = Matrix4x4.Scale(new Vector3(2, 2, 2));
	
		if(GUILayout.Button("Init Chatboost")) {
			#if UNITY_IOS
			Chartboost.init("54ca1abf04b0163ff3221c8d", "c232af7185297173942d04877791032505ec4c08");
			#elif UNITY_ANDROID
			Chartboost.init("54ca2d4cc909a67eaaad9bad", "c85f8a761c7e159ddfcdc37f0e96141a65a1ad8a");
			#endif
		}

		if(GUILayout.Button("Cache Interstitial")) {
			Chartboost.cacheInterstitial(CBLocation.Default);
		}
		
		if(GUILayout.Button("Show Interstitial")) {
			if(Chartboost.hasInterstitial(CBLocation.Default)) {
				Chartboost.showInterstitial(CBLocation.Default);
				//Invoke("randShow", 0.1f);
			} else {
				Debug.Log("Interstitial ad has not cached yet");
			}
		}
		
		if(GUILayout.Button("Cache More Apps")) {
			Chartboost.cacheMoreApps(CBLocation.Default);
		}
		
		if(GUILayout.Button("Show More Apps")) {
			if(Chartboost.hasMoreApps(CBLocation.Default)) {
				Chartboost.showMoreApps(CBLocation.Default);
				//Invoke("randShow", 0.1f);
			} else {
				Debug.Log("Moreapps has not cached yet");
			}
		}
		
		if(GUILayout.Button("Cache Rewarded Video")) {
			Chartboost.cacheRewardedVideo(CBLocation.Default);
		}
		
		if(GUILayout.Button("Show Rewarded Video")) {
			if(Chartboost.hasRewardedVideo(CBLocation.Default)) {
				Chartboost.showRewardedVideo(CBLocation.Default);
				//Invoke("randShow", 0.1f);
			} else {
				Debug.Log("Reward video ad has not cached yet");
			}
		}
		
		if(GUILayout.Button("Cache InPlay Ad")) {
			Chartboost.cacheInPlay(CBLocation.Default);
		}
		
		if(GUILayout.Button("Show InPlay Ad")) {
			if(Chartboost.hasInPlay(CBLocation.Default)) {
				inPlayAd = Chartboost.getInPlay(CBLocation.Default);
				if(inPlayAd != null) {
					// Set the texture of InPlay Ad Icon
					// Link its onClick() event with inPlay's click()
					inPlayIcon.guiTexture.texture = inPlayAd.appIcon;
					inPlayText.guiText.text = inPlayAd.appName;
					inPlayAd.show();
				}
			} else {
				Debug.Log("InPlayAd has not cached yet");
			}
		}
		#endif
	}


	void randShow() {
		//show = true;
		if(UnityEngine.Random.Range(0, 2) == 0) {
			show = true;
		} else {
			show = false;
		}
		Debug.Log("Will Show Ad..? " + show);
	}

	void didFailToLoadInterstitial(CBLocation location, CBImpressionError error) {
		Debug.Log(string.Format("didFailToLoadInterstitial: {0} at location {1}", error, location));
	}

	void didDismissInterstitial(CBLocation location) {
		Debug.Log("didDismissInterstitial: " + location);
	}

	void didCloseInterstitial(CBLocation location) {
		Debug.Log("didCloseInterstitial: " + location);
	}

	void didClickInterstitial(CBLocation location) {
		Debug.Log("didClickInterstitial: " + location);
	}

	void didCacheInterstitial(CBLocation location) {
		Debug.Log("didCacheInterstitial: " + location);
	}

	bool show = true;
	bool shouldDisplayInterstitial(CBLocation location) {
		Debug.Log("shouldDisplayInterstitial: " + location);
		return show;
	}

	void didDisplayInterstitial(CBLocation location) {
		Debug.Log("didDisplayInterstitial: " + location);
	}

	void didFailToLoadMoreApps(CBLocation location, CBImpressionError error) {
		Debug.Log(string.Format("didFailToLoadMoreApps: {0} at location: {1}", error, location));
	}

	void didDismissMoreApps(CBLocation location) {
		Debug.Log(string.Format("didDismissMoreApps at location: {0}", location));
	}

	void didCloseMoreApps(CBLocation location) {
		Debug.Log(string.Format("didCloseMoreApps at location: {0}", location));
	}

	void didClickMoreApps(CBLocation location) {
		Debug.Log(string.Format("didClickMoreApps at location: {0}", location));
	}

	void didCacheMoreApps(CBLocation location) {
		Debug.Log(string.Format("didCacheMoreApps at location: {0}", location));
	}

	bool shouldDisplayMoreApps(CBLocation location) {
		Debug.Log(string.Format("shouldDisplayMoreApps at location: {0}", location));
		return show;
	}

	void didDisplayMoreApps(CBLocation location) {
		Debug.Log("didDisplayMoreApps: " + location);
	}

	void didFailToRecordClick(CBLocation location, CBImpressionError error) {
		Debug.Log(string.Format("didFailToRecordClick: {0} at location: {1}", error, location));
	}

	void didFailToLoadRewardedVideo(CBLocation location, CBImpressionError error) {
		Debug.Log(string.Format("didFailToLoadRewardedVideo: {0} at location {1}", error, location));
	}

	void didDismissRewardedVideo(CBLocation location) {
		Debug.Log("didDismissRewardedVideo: " + location);
	}

	void didCloseRewardedVideo(CBLocation location) {
		Debug.Log("didCloseRewardedVideo: " + location);
	}

	void didClickRewardedVideo(CBLocation location) {
		Debug.Log("didClickRewardedVideo: " + location);
	}

	void didCacheRewardedVideo(CBLocation location) {
		Debug.Log("didCacheRewardedVideo: " + location);
	}

	bool shouldDisplayRewardedVideo(CBLocation location) {
		Debug.Log("shouldDisplayRewardedVideo: " + location);
		return show;
	}

	void didCompleteRewardedVideo(CBLocation location, int reward) {
		Debug.Log(string.Format("didCompleteRewardedVideo: reward {0} at location {1}", reward, location));
	}

	void didDisplayRewardedVideo(CBLocation location) {
		Debug.Log("didDisplayRewardedVideo: " + location);
	}

	void didCacheInPlay(CBLocation location) {
		Debug.Log("didCacheInPlay called: " + location);
	}

	void didFailToLoadInPlay(CBLocation location, CBImpressionError error) {
		Debug.Log(string.Format("didFailToLoadInPlay: {0} at location: {1}", error, location));
	}

	void didPauseClickForConfirmation() {
		Debug.Log("didPauseClickForConfirmation called");
	}

	void willDisplayVideo(CBLocation location) {
		Debug.Log("willDisplayVideo: " + location);
	}

	#if UNITY_IPHONE
	void didCompleteAppStoreSheetFlow() {
		Debug.Log("didCompleteAppStoreSheetFlow");
	}
	#endif
}


