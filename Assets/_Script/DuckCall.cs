using UnityEngine;
using System.Collections;

public class DuckCall : MonoBehaviour
{
	
	public QuackBehavior quackBehavior;
	
	public void Display ()
	{
		print("I'm duck call device");
	}
	
	
	public void PerformQuack()
	{
		quackBehavior.quack();
	}
	public void SetQuackBehavior(QuackBehavior qb)
	{
		quackBehavior = qb;
	}
	
	public void Swim()
	{
		duck.Swim();
	}
	
}

