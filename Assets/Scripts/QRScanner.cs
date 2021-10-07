using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using UnityEngine.Events;
using Newtonsoft.Json;

public class QRScanner : MonoBehaviour
{
    WebCamTexture webcamTexture;
    string QrCode = string.Empty;
   public string id = "";
  
    public UnityEvent onScanSuccess;
    public ServiceDetailsPanelController serviceDetailsPanel;
    void Start()
    {
      
        var renderer = GetComponent<RawImage>();
        webcamTexture = new WebCamTexture(512, 512);
        renderer.material.mainTexture = webcamTexture;
        StartCoroutine(GetQRCode());
    }

    IEnumerator GetQRCode()
    {
        IBarcodeReader barCodeReader = new BarcodeReader();
        webcamTexture.Play();
        var snap = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.ARGB32, false);
        while (string.IsNullOrEmpty(QrCode))
        {
            try
            {
                snap.SetPixels32(webcamTexture.GetPixels32());
                var Result = barCodeReader.Decode(snap.GetRawTextureData(), webcamTexture.width, webcamTexture.height, RGBLuminanceSource.BitmapFormat.ARGB32);
                if (Result != null)
                {
                    QrCode = Result.Text;
                    try
                    {
                        AdsManager.instance.UserChoseToWatchAd();
                        onScanSuccess.Invoke();
                    }
                    catch(Exception e )
                    {
                        Debug.LogError(e.Message);
                    }
                    SubscribeToQueue();
                    if (!string.IsNullOrEmpty(QrCode))
                    {
                        Debug.Log("DECODED TEXT FROM QR: " + QrCode);
                        break;
                    }
                }
            }
            catch (Exception ex) { Debug.LogWarning(ex.Message); }
            yield return null;
        }
        webcamTexture.Stop();
    }
    public void SubscribeToQueue()
    {
        string json = SecurityManager.Base64Decode(QrCode);
        QrCode = json;
        ServiceStation detectedService = JsonConvert.DeserializeObject<ServiceStation>(json);
        serviceDetailsPanel.service = detectedService;
        serviceDetailsPanel.UpdatePanel();

        //Load ServiceStationFromDatabase add Relation to it then save it  again to database


    }
    
    private void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 50;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        string text =QrCode;
        GUI.Label(rect, text, style);
    }
}
