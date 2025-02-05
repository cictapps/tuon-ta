using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardButtonController : MonoBehaviour
{
    [SerializeField] private Sprite cardThumbnail;
    [SerializeField] private string cardName;
    [SerializeField] private string cardDescription;

    [SerializeField] private string cardDestination;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Transform cardTransform = this.transform;
      
        cardTransform.Find("CardThumb").GetComponent<UnityEngine.UI.Image>().sprite = cardThumbnail;
        cardTransform.Find("CardName").GetComponent<TextMeshProUGUI>().text = cardName;
        cardTransform.Find("CardDescription").GetComponent<TextMeshProUGUI>().text = cardDescription;       
        this.GetComponent<Button>().onClick.AddListener(()=>this.GetComponent<MasterNavigator>().NavigateTo(cardDestination));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
