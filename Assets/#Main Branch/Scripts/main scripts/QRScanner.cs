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
    void   Start()
    {
        var renderer = GetComponent<RawImage>();
        webcamTexture = new WebCamTexture(512, 512);
        renderer.texture = webcamTexture;
        ScanAgain();

    }
   public void ScanAgain()
    {
       
        StartCoroutine(GetQRCode());
    }

    IEnumerator GetQRCode()
    {
      
        IBarcodeReader barCodeReader = new BarcodeReader();
        webcamTexture.Play();
        detectedService = new ServiceStation();
        var snap = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.ARGB32, false);
        while (string.IsNullOrWhiteSpace( detectedService.name))
        {
            try
            {
                snap.SetPixels32(webcamTexture.GetPixels32());
                var Result = barCodeReader.Decode(snap.GetRawTextureData(), webcamTexture.width, webcamTexture.height, RGBLuminanceSource.BitmapFormat.ARGB32);
                if (Result != null)
                {
                    QrCode = Result.Text;
                    SubscribeToQueue();
                    if (!string.IsNullOrEmpty(QrCode))
                    {
                        Debug.Log("DECODED TEXT FROM QR: " + QrCode);
                      //  break;
                    }
                }
            }
            catch (Exception ex) { Debug.LogWarning(ex.Message); }
            yield return null;
        }
        try
        {
            
            //AdsManager.instance.UserChoseToWatchAd();
            onScanSuccess.Invoke();
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
       
        webcamTexture.Stop();
    }

  public  ServiceStation detectedService=new ServiceStation();
    public void SubscribeToQueue()
    {
        try
        {
            string json = SecurityManager.Base64Decode(QrCode);
            QrCode = json;
            detectedService = JsonConvert.DeserializeObject<ServiceStation>(json);
            serviceDetailsPanel.service = detectedService;
            serviceDetailsPanel.UpdatePanel();

        }catch(Exception e)
        {
            Debug.Log(e.Message);
        }

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
