using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public string cardName;
    public cardData data;
    public Sprite cardSprite;
    public int heroIndex;

    void Awake()
    {
        data = Resources.Load<cardData>(cardName);
    }
    public void ChoosePlayer()
    {
        PlayerPrefs.SetInt("SelectHero",data.cardindex);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Game");        
    }
}
