using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GlobalCoroutineHandler : MonoBehaviour
{
	#region Singleton
	public static GlobalCoroutineHandler Instance;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	#endregion

	public void PlayCoroutineWithTime(Action functionToExecute, float secondsToWait)
	{
		StartCoroutine(Play(functionToExecute, secondsToWait));
	}

    public void PlayPlayCoroutineWithCondition(Action functionToExecute, Func<bool> condition)
    {
        StartCoroutine(Play(functionToExecute, condition));
    }

    public void PlayPlayCoroutineWithTimeAndCondition(Action functionToExecute, Func<bool> condition, float secondsToWait)
    {
        StartCoroutine(Play(functionToExecute, condition, secondsToWait));
    }

    private IEnumerator Play(Action action, float seconds)
	{
		yield return new WaitForSeconds(seconds);
		action();
	}

    private IEnumerator Play(Action action, Func<bool> condition)
    {
        yield return new WaitUntil(() => condition() == true);
        action();
    }

    private IEnumerator Play(Action action, Func<bool> condition, float seconds)
    {
        yield return new WaitUntil(() => condition() == true);
        yield return new WaitForSeconds(seconds);
        action();
    }
}