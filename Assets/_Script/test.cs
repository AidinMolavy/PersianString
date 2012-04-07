using UnityEngine;
using System.Collections;
public class test : MonoBehaviour
{
	
	public delegate long FactorialDelegate(long n);
	// Use this for initialization

	
	public static void FunctionInFunction()
	{
	    // Nested function.
		long aidin = 0;
		
	    FactorialDelegate FactorialMethod = delegate(long number)
	    {
	     

	
	        
			aidin = number;
	        // Calculate factorial
	      	print(aidin);
	       return aidin;
	
	        
	    };
		FactorialMethod(20);

	}
	
	void Start()
	{
		FunctionInFunction();
	}
	
}

//void PlayAudioClip(AudioClip clip, string Action)
//	{		
//		audio.Stop();
//		audio.clip = clip;
//		audio.Play();
//		
//		if(Action != "Over" )
//		{							
//			isGuiEnabled = false;			
//			yield return new WaitForSeconds(audio.clip.length);
//			
//			if( Action == "2D" )
//			{
//				Application.LoadLevel("2DGame");
//			}
//			
//			isGuiEnabled = true;	
//		}		
//	}
//
//
//Assets/Scripts/MainMenu/S_MainMenu.cs(52,14): error CS1624:
// The body of `S_MainMenu.PlayAudioClip(UnityEngine.AudioClip, string)'
// cannot be an iterator block because `void' is not an iterator interface type



