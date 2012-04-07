using UnityEngine;
using System.Collections;

public class MallardDuck : Duck
{
	public MallardDuck()
	{
		flyBehavior = new FlyWithWings();
		quackBehavior = new Quack();
	}
	
	public override void Display()
	{
		print("I'm real mallard duck");
	}
}

