using UnityEngine;
using GoogleMobileAds.Api;

public class InterstialAd : MonoBehaviour
{
    private int _shotsCount = 0;
    private InterstitialAd _interstitialAd;

    private void Start()
    {
        CreateInterstitialAd();
    }

    private void CreateInterstitialAd()
    {
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";

        _interstitialAd = new InterstitialAd(adUnitId);

        AdRequest _adRequest = new AdRequest.Builder().Build();

        _interstitialAd.LoadAd(_adRequest);
    }

    private void LoadInterstitialAd()
    {
        if (_interstitialAd.IsLoaded())
            _interstitialAd.Show();
    }

    public void AddShotToCount()
    {
        _shotsCount++;

        if(_shotsCount == 14)
        {
            LoadInterstitialAd();
            _shotsCount = 0;
        }
    }
}
