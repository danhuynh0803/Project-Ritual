using UnityEngine;
using System.Collections;

public class PatientCondition : MonoBehaviour {

	public int numberOfPatients = 3;

	private bool[] answerArray = new bool[9];
	private ArrayList sicknessArray = new ArrayList();

	private int conditionTextIndex;

	void Start() 
	{
		LoadConditions(numberOfPatients);
	}

	// Choose a random set of answers for each patient
	public bool[] ChooseCondition()	
	{
		conditionTextIndex = Random.Range(0, sicknessArray.Capacity - 1);
		return (bool[]) sicknessArray[conditionTextIndex];
	}

	// Select a random answer within each category to be correct
	bool[] RandomizeConditions() 
	{
		bool[] randomSicknessArray = new bool[9];
		int index;

		index = Random.Range(0,2);
		randomSicknessArray[index] = true;

		index = Random.Range(3,5);
		randomSicknessArray[index] = true;

		index = Random.Range(6,8);
		randomSicknessArray[index] = true;

		return randomSicknessArray;
	}

	void LoadConditions(int numberOfEnemies)
	{
		
		for (int i = 0; i < numberOfEnemies; i++)
		{
			sicknessArray.Add(RandomizeConditions());
		}
	}

	public string LoadConditionText(int conditionTextIndex)
	{
		return "";
	}
}
