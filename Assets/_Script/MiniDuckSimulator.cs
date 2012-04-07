using UnityEngine;
using System.Collections;

public class MiniDuckSimulator : MonoBehaviour
{
	
	
	// Use this for initialization
	void Start ()
	{
		
		Duck millard = new MallardDuck();
		
		millard.PerformQuack();
		millard.PerformFly();
		
		millard.SetFlyBehavior(new FlyNoWay());
		millard.SetQuackBehavior(new MuteQuack());
		
		millard.PerformQuack();
		millard.PerformFly();
		
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
}

