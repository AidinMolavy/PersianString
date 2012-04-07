using UnityEngine;
using System.Collections;

public abstract class Duck : MonoBehaviour
{
	 public FlyBehavior   flyBehavior; 
	 public QuackBehavior quackBehavior;
	
	public Duck(){}
	public abstract void Display();
	
	public void PerformQuack()
	{
		quackBehavior.quack();
	}
	
	public void PerformFly()
	{
		flyBehavior.fly();
	}
	
	public void SetFlyBehavior(FlyBehavior fb)
	{
		flyBehavior = fb;
	}
	
	public void SetQuackBehavior(QuackBehavior qb)
	{
		quackBehavior = qb;
	}
	
	public void Swim()
	{
		print("All ducks float, even decoys.");
	}

}

