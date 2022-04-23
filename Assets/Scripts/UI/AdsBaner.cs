using UnityEngine;
using GoogleMobileAds.Api;

public class AdsBaner : MonoBehaviour
{
    private BannerView _banner;

    void Start()
    {
        MobileAds.Initialize(initStatus => { });

        CreateBanner();
    }

    private void CreateBanner()
    {
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";

        _banner = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        _banner.LoadAd(request);
    }
}
