using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSckin : MonoBehaviour
{
    // Код максимально простой (был простой). Через инспектор вбиваем нейм скина, ключ не трогаем
    string key = "PlayerSkin";
    [SerializeField]
    string name;

    //Аве делегатам и ивентам. Вызывается при покупке скина
    public delegate void PurchaseSckin();
    public static event PurchaseSckin Purchase;


    //Парметры для покупки скина. Планировал сделать отдельный скрипт, однако появились причины по которым это стало не возможно.
    //Точнее возможно, но код становится слишком сложным, пусть и становится два скрипта
    [SerializeField]
    int price;
    bool purchase;

    [SerializeField]
    Text textForPrice, textForError;

    [SerializeField]
    Wallet wallet;


    private void Start()
    {
        
            if (PlayerPrefs.HasKey(name + "Purchase"))
        {
            purchase = System.Convert.ToBoolean(PlayerPrefs.GetString(name + "Purchase"));
        }
        if (purchase)
        {
            textForPrice.text = "Куплено";
        }
        else
        {
            wallet = FindObjectOfType<Wallet>();
            textForPrice.text = System.Convert.ToString(price);
        }
    }


 // При нажатии на скин сейвится выбранный скин если он куплен. Иначе производится покупка. Доп проверки конечно можно ввести ("Вы уверены?" и т.д)
    //Но в данный момент в них нет необходимости
    private void OnMouseDown()
    {
        if (purchase)
        {
            PlayerPrefs.SetString(key, name);
            PlayerPrefs.Save();
        }
        else
        {
            if (wallet.Account >= price)
            {
                wallet.Account -= price;
                purchase = true;
                PlayerPrefs.SetString(name + "Purchase", "true");
                textForPrice.text = "Куплено";
                PlayerPrefs.SetInt("Wallet", wallet.Account);
                Purchase();
            }
            else
            {
                textForError.text = "Нехватака средств. Слышь, задонь";
                textForError.enabled = true;
            }
        }
    }
}
