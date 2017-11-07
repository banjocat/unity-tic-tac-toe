using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{

    public Button button;
    public Text buttonText;

    private GameController _gameController;

    public void SetGameControllerReference(GameController controller)
    {
        _gameController = controller;
    }
    public void SetSpace()
    {
        Debug.Log("Set space to " + _gameController.GetPlayerSide());
        buttonText.text = _gameController.GetPlayerSide();
        button.interactable = false;
        _gameController.EndTurn();
    }
}
