using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class QRCodeGenerator : MonoBehaviour {

    // Use this for initialization
    public string text;
    public RawImage rawImage;

	void Start () {

      /*  Texture2D myQR = generateQR(text);
        rawImage.texture = myQR;
        byte[] bytes = myQR.EncodeToPNG();
        Emailer.SendAnEmail("Voici votre QRcode de Service nommé: Madhmoun_1", bytes);
      */
    }
    public void GenerateQRCode(string text,ServiceStation service)
    {
        Texture2D myQR = generateQR(text);
        rawImage.texture = myQR;
        byte[] bytes = myQR.EncodeToPNG();
        Emailer.SendAnEmail(UserManager.instance.user.email,"Voici votre QRcode de Service nommé:"+service.name+" window: "+service.windowNumber,service.name, bytes);
    }
	
	// Update is called once per frame
	void Update () {
       // Texture2D myQR = generateQR(text);
      //  rawImage.texture = myQR;
    }

    void OnGUI() {
        return;
        Texture2D myQR = generateQR("test");
        if (GUI.Button(new Rect(300, 300, 256, 256), myQR, GUIStyle.none)) { }
    }

    public Texture2D generateQR(string text)
    {
        var encoded = new Texture2D(256, 256);
        var color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        return encoded;
    }

    private static Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }
}
