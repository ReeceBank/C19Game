using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Share : MonoBehaviour
{
    private string shareMessage;
	private leaderboard leaderboard;

    public void Start()
    {
		leaderboard = GameObject.Find("Leaderboard").GetComponent<leaderboard>();
    }
    public void shareClick()
    {
		shareMessage = "Look who scored a whopping " + leaderboard.get_highscore()[1] + " points in Cards Against Coronavirus, can anyone do better?";
		
		Debug.Log(shareMessage);

		StartCoroutine(TakeScreenshotAndShare());
    }
	private IEnumerator TakeScreenshotAndShare()
	{
		yield return new WaitForEndOfFrame();

		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();

		string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
		File.WriteAllBytes(filePath, ss.EncodeToPNG());

		// To avoid memory leaks
		Destroy(ss);

		new NativeShare().AddFile(filePath)
			.SetSubject("Cards Against Coronavirus").SetText(shareMessage)
			.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
			.Share();
	}
}
