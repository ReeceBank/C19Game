using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Share : MonoBehaviour
{
	//create constuctors to use later
    private string shareMessage;
	private leaderboard leaderboard;

    public void Start()
    {
		//finds the leaderboard script so we can get the highest score on there to share
		leaderboard = GameObject.Find("Leaderboard").GetComponent<leaderboard>();
    }

	//share click is on the share button in the leaderboard scene. 
	//it begins the coroutine to share your best score online.
    public void shareClick()
    {
		//the message that is automatically put at the top of any screen shot shared.
		//uses gethighscore from the leaderbaord scrip to find the highest scoring point. can also get the name of the person
		//who scored the highest if we change the index from 1 to 0
		shareMessage = "Look who scored a whopping " + leaderboard.get_highscore()[1] + " points in Cards Against Coronavirus, can anyone do better?";
		
		//to make sure the string is correct
		Debug.Log(shareMessage);

		StartCoroutine(TakeScreenshotAndShare());
    }
	//all this is a method that is used for the free asset we imported called "take and share for android and ios"
	//it takes a screenshot of the screem, and is passed a string then shares that screenshot with the string as a message
	//onto any social media site the user has installed, such as twitter or discord etc.
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

		//gets the screenshot, takes a string, and sends it over to the native share side of the code to share it on the web.
		//this is not our creation, the rest is.
		new NativeShare().AddFile(filePath)
			.SetSubject("Cards Against Coronavirus").SetText(shareMessage)
			.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
			.Share();
	}
}
