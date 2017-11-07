using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public Text[] ButtonList;
	public Text GameOverText;
	public GameObject GameOverPanel;

	private string _playerSide;
	private int _moveCount;

	void Awake()
	{
		_playerSide = "X";
		_moveCount = 0;
		GameOverPanel.SetActive(false);
		SetGameControllerReferenceOnButtons();
	}

	void SetGameControllerReferenceOnButtons()
	{
		for (var i = 0; i < ButtonList.Length; i++)
		{
			ButtonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
		}

	}

	public string GetPlayerSide()
	{
		return _playerSide;
	}

	public void EndTurn()
	{
		_moveCount++;
		if ((ButtonList[0].text == _playerSide && ButtonList[1].text == _playerSide && ButtonList[2].text == _playerSide)
		    || (ButtonList[3].text == _playerSide && ButtonList[4].text == _playerSide && ButtonList[5].text == _playerSide)
		    || (ButtonList[6].text == _playerSide && ButtonList[7].text == _playerSide && ButtonList[8].text == _playerSide)
		    || (ButtonList[0].text == _playerSide && ButtonList[3].text == _playerSide && ButtonList[6].text == _playerSide)
		    || (ButtonList[1].text == _playerSide && ButtonList[4].text == _playerSide && ButtonList[7].text == _playerSide)
		    || (ButtonList[2].text == _playerSide && ButtonList[5].text == _playerSide && ButtonList[8].text == _playerSide)
		    || (ButtonList[0].text == _playerSide && ButtonList[4].text == _playerSide && ButtonList[8].text == _playerSide)
		    || (ButtonList[2].text == _playerSide && ButtonList[4].text == _playerSide && ButtonList[6].text == _playerSide))

		{
			GameOver();
		}
		ChangeSides();
		if (_moveCount >= 9)
		{
			SetGameOverText("It's a draw!");
		}
	}

	void SetGameOverText(string value)
	{
		GameOverPanel.SetActive(true);
		GameOverText.text = value;
	}

	public void RestartGame()
	{
		_playerSide = "X";
		_moveCount = 0;
		GameOverPanel.SetActive(false);
		SetBoardInteractable(true);
	}

	void SetBoardInteractable(bool toggle)
	{
		foreach (var button in ButtonList)
		{
			button.GetComponentInParent<Button>().interactable = toggle;
			button.text = "";
		}
	}

	void GameOver()
	{
		SetBoardInteractable(false);
		SetGameOverText(_playerSide + " Wins!");

	}

	void ChangeSides()
	{
		_playerSide = _playerSide == "X" ? "O" : "X";
	}
}
