using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class GrimoireMenu : MonoBehaviour {
	
	private bool isIngredientSelected; 
	private bool isFloorSelected; 
	private bool isPoseSelected; 

	public bool[] selectionArray = new bool[9]; 
	public bool[] answerArray = new bool[9];
	
	public GameObject ritual;	
	public Text conditionText; 


	public GameObject button0;
	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;
	public GameObject button5;
	public GameObject button6;
	public GameObject button7;
	public GameObject button8;

	// Store buttons for ease of access to change color
	private ArrayList buttonList = new ArrayList();

	public PatientCondition patientConditionGenerator; 


	void Start()
	{		
		ritual.GetComponent<Button>().interactable = false;
		patientConditionGenerator = FindObjectOfType<PatientCondition>();

		// Store a random answer set
		answerArray = patientConditionGenerator.ChooseCondition();

		loadButtons();
	}

	void Update() 
	{
		if (!isCombinationSet()) 
			ritual.GetComponent<Button>().interactable = false;
		else 
			ritual.GetComponent<Button>().interactable = true;
	}
	
	public bool isCombinationSet() 
	{
		return (isIngredientSelected && isFloorSelected && isPoseSelected);
	}


	// Store player input within selection array
	/*
	*
	public void PressedButton()
	{
		//int index = int.Parse(tag);
		//Debug.Log(index);
	}

	*/

	private void loadButtons() 
	{
		buttonList.Add(button0);
		buttonList.Add(button1);
		buttonList.Add(button2);
		buttonList.Add(button3);
		buttonList.Add(button4);
		buttonList.Add(button5);
		buttonList.Add(button6);
		buttonList.Add(button7);
		buttonList.Add(button8);
	}

	private void setButtonInteractive(int index) 
	{
		// A button within this category has already been selected
		switch (index) 
		{
			case 0: 
				button0.GetComponent<Button>().interactable = false;
				button1.GetComponent<Button>().interactable = true;
				button2.GetComponent<Button>().interactable = true;
				selectionArray[0] = true; 
				selectionArray[1] = false; 
				selectionArray[2] = false;
				break; 
			case 1: 
				button0.GetComponent<Button>().interactable = true;
				button1.GetComponent<Button>().interactable = false;
				button2.GetComponent<Button>().interactable = true;
				selectionArray[0] = false; 
				selectionArray[1] = true;
				selectionArray[2] = false;
				break; 
			case 2: 
				button0.GetComponent<Button>().interactable = true;
				button1.GetComponent<Button>().interactable = true;
				button2.GetComponent<Button>().interactable = false;
				selectionArray[0] = false;
				selectionArray[1] = false; 
				selectionArray[2] = true;
				break; 
			case 3: 
				button3.GetComponent<Button>().interactable = false;
				button4.GetComponent<Button>().interactable = true;
				button5.GetComponent<Button>().interactable = true;
				selectionArray[3] = true; 
				selectionArray[4] = false; 
				selectionArray[5] = false;
				break; 
			case 4: 
				button3.GetComponent<Button>().interactable = true;
				button4.GetComponent<Button>().interactable = false;
				button5.GetComponent<Button>().interactable = true;
				selectionArray[3] = false; 
				selectionArray[4] = true;
				selectionArray[5] = false;
				break; 
			case 5: 
				button3.GetComponent<Button>().interactable = true;
				button4.GetComponent<Button>().interactable = true;
				button5.GetComponent<Button>().interactable = false;
				selectionArray[3] = false;
				selectionArray[4] = false; 
				selectionArray[5] = true;
				break; 
			case 6: 
				button6.GetComponent<Button>().interactable = false;
				button7.GetComponent<Button>().interactable = true;
				button8.GetComponent<Button>().interactable = true;
				selectionArray[6] = true; 
				selectionArray[7] = false; 
				selectionArray[8] = false;
				break; 
			case 7: 
				button6.GetComponent<Button>().interactable = true;
				button7.GetComponent<Button>().interactable = false;
				button8.GetComponent<Button>().interactable = true;
				selectionArray[6] = false; 
				selectionArray[7] = true;
				selectionArray[8] = false;
				break; 
			case 8: 
				button6.GetComponent<Button>().interactable = true;
				button7.GetComponent<Button>().interactable = true;
				button8.GetComponent<Button>().interactable = false;
				selectionArray[6] = false;
				selectionArray[7] = false; 
				selectionArray[8] = true;
				break; 
		}
	}

	public void onPressedButton0()
	{
		if (isIngredientSelected) 
		{
			setButtonInteractive(0);
		}
		else 
		{
			button0.GetComponent<Button>().interactable = false;
			isIngredientSelected = true;
			selectionArray[0] = !selectionArray[0];
		}
	}

	public void onPressedButton1() 
	{
		if (isIngredientSelected) 
		{
			setButtonInteractive(1);
		}
		else 
		{
			button1.GetComponent<Button>().interactable = false;
			isIngredientSelected = true;
			selectionArray[1] = !selectionArray[1];
		}
	}

	public void onPressedButton2() 
	{
		if (isIngredientSelected) 
		{
			setButtonInteractive(2);
		}
		else 
		{
			button2.GetComponent<Button>().interactable = false;
			isIngredientSelected = true;
			selectionArray[2] = !selectionArray[2];
		}
	}

	public void onPressedButton3()
	{
		if (isFloorSelected) 
		{
			setButtonInteractive(3);
		}
		else 
		{
			button3.GetComponent<Button>().interactable = false;
			isFloorSelected = true;
			selectionArray[3] = !selectionArray[3];
		}
	}

	public void onPressedButton4() 
	{
		if (isFloorSelected) 
		{
			setButtonInteractive(4);
		}
		else 
		{
			button4.GetComponent<Button>().interactable = false;
			isFloorSelected = true;
			selectionArray[4] = !selectionArray[4];
		}
	}

	public void onPressedButton5() 
	{
		if (isFloorSelected) 
		{
			setButtonInteractive(5);
		}
		else 
		{
			button5.GetComponent<Button>().interactable = false;
			isFloorSelected = true;
			selectionArray[5] = !selectionArray[5];
		}
	}

	public void onPressedButton6()
	{
		if (isPoseSelected) 
		{
			setButtonInteractive(6);
		}
		else 
		{
			button6.GetComponent<Button>().interactable = false;
			isPoseSelected = true;
			selectionArray[6] = !selectionArray[6];
		}
	}
	
	public void onPressedButton7() 
	{
		if (isPoseSelected) 
		{
			setButtonInteractive(7);
		}
		else 
		{
			button7.GetComponent<Button>().interactable = false;
			isPoseSelected = true;
			selectionArray[7] = !selectionArray[7];
		}
	}

	public void onPressedButton8() 
	{
		if (isPoseSelected) 
		{
			setButtonInteractive(8);
		}
		else 
		{
			button8.GetComponent<Button>().interactable = false;
			isPoseSelected = true;
			selectionArray[8] = !selectionArray[8];
		}
	}
	
	public void checkCombination()
	{
		for (int i = 0; i < answerArray.Length; i++)
		{
			// Check if player chose incorrectly
			if (answerArray[i] == true && selectionArray[i] == false)
			{
				// Incorrect 
				Debug.Log("Failure");
			}
			else if (answerArray[i] == true && selectionArray[i] == true)
			{
				// Correct
				Debug.Log("Success");
			}
		}
	}
}
 