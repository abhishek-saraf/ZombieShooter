using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AssetBundleManagerScript : MonoBehaviour
{
    public static AssetBundleManagerScript instance;

    // Variable to hold the Asset Bundle of our game - helpful for unloading.
    private AssetBundle bundle;

    public GameObject pistol, rifle, zombie;

    [SerializeField] private GameObject _startButton;

    UnityWebRequest www;

    [SerializeField] private Slider downloadProgress;

    private void Awake()
    {
        instance = this;
        DownloadAssetBundle();
    }

    private void Update()
    {
        if (bundle == null)
        {
            _startButton.SetActive(false);
            downloadProgress.value = www.downloadProgress;
            Debug.Log(www.downloadProgress);
        }
        else
        {
            _startButton.SetActive(true);
        }
    }

    // Download the asset bundle.
    private void DownloadAssetBundle()
    {
        StartCoroutine(GetAssetBundle());
    }

    // Unload the asset bundle when the game is restarted, or on quit.
    private void OnDisable()
    {
        bundle.Unload(true);
    }

    IEnumerator GetAssetBundle()
    {
        www = UnityWebRequestAssetBundle.GetAssetBundle("https://firebasestorage.googleapis.com/v0/b/zombiesurvival-2b0b2.appspot.com/o/myassetbundle?alt=media&token=ff0c8e72-c1d9-4737-9c9d-04fe95acf459");
    
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            bundle = DownloadHandlerAssetBundle.GetContent(www);

            if (bundle != null)
            {
                pistol = bundle.LoadAsset<GameObject>("Assets/Resources/Pistol.prefab");
                rifle = bundle.LoadAsset<GameObject>("Assets/Resources/AK-47.prefab");
                zombie = bundle.LoadAsset<GameObject>("Assets/Resources/Zombie.prefab");
            }
        }
    }
}
