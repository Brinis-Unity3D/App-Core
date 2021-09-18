using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ExperienceImporterPostLoad : MonoBehaviour
{
  //  [HideInInspector]
    public string ImagePath = "";
    [HideInInspector]
    public Image image;

    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
    }
#if UNITY_EDITOR
    // Update is called once per frame
    void Update()
    {
        return;
        if(Time.realtimeSinceStartup<2)
        if (ImagePath.Length > 0 && image.sprite == null)
        {
            TextureImporter importer = AssetImporter.GetAtPath(ImagePath) as TextureImporter;
            if(importer)
            importer.textureType = TextureImporterType.Sprite;
            AssetDatabase.ImportAsset(importer.assetPath, ImportAssetOptions.ForceUpdate);
            string filename = Path.GetFileNameWithoutExtension(ImagePath);
            string directory = Path.GetDirectoryName(ImagePath.Replace("Assets/Resources/", ""));
            image.sprite = Resources.Load<Sprite>(Path.Combine(directory, filename));

           // image.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(ImagePath);
        }
    }
#endif
}
