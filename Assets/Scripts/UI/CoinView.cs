using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//handels the visual representation of a runtime coin
public class CoinView : MonoBehaviour
{
    //image showing the coin
    [SerializeField] private Image _coinImage;

    //button used for clicking
    [SerializeField] private Button _button;

    //the runtime coin
    private Coin _coin;

    //set the coin this view represents
    public void Setup(Coin newCoin)
    {
        _coin = newCoin;

        UpdateVisual();
    }

    //update the coin image
    public void UpdateVisual()
    {
        //check if there is a coin
        if (_coin == null) return;

        //show heads image
        if (_coin.CurrentSide == _coin.Data.Heads)
        {
            _coinImage.sprite = _coin.Data.HeadsSprite;
        }
        //show tials image
        else if (_coin.CurrentSide == _coin.Data.Tails)
        {
            _coinImage.sprite = _coin.Data.TailsSprite;
        }
    }

    //add a click event
    public void SetClickAction(UnityAction action)
    {
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(action);
    }
}
