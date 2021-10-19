using UnityEngine;
using System.Collections;

public class BrowserOpener : MonoBehaviour {

	public string pageToOpen = "http://www.google.com";

    // check readme file to find out how to change title, colors etc.
    public void OnButtonClicked(string title)
    {
        InAppBrowser.DisplayOptions options = new InAppBrowser.DisplayOptions();
        options.displayURLAsPageTitle = false;
        options.pageTitle = title;//"InAppBrowser example";
                                  // InAppBrowser.ExecuteJS("");

        //Input.location.lastData.

        InAppBrowser.OpenURL(pageToOpen, options);
    }
    public void OnShowHTMl(string title)
    {
        InAppBrowser.DisplayOptions options = new InAppBrowser.DisplayOptions();
        options.displayURLAsPageTitle = false;
        options.pageTitle = title;//"InAppBrowser example";
        InAppBrowser.LoadHTML(pageToOpen, options);
    }
    public void OnClearCacheClicked() {
		InAppBrowser.ClearCache();
	}
}
