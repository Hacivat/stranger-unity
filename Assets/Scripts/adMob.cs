using GoogleMobileAds.Api;
using UnityEngine;

public class adMob : MonoBehaviour {
	private BannerView bannerView;

	// Use this for initialization
	public void Start()

	{
		this.RequestBanner();
	}

	private void RequestBanner()
	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-1001207100386493/5790292669";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/2934735716";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, new AdSize(320, 50), AdPosition.Bottom);

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();

		// Load the banner with the request.
		bannerView.LoadAd(request);
	}
}