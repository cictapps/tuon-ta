using UnityEngine;
using DG.Tweening;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private RectTransform settingsGroup;

    int toggleIsOn = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingsGroup.DOMove(new Vector2(0, -522), 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSettings()
    {
        if (toggleIsOn == 0)
        {
            toggleIsOn = 1;
            settingsGroup.DOMove(new Vector2(0, 0), 1f);
        }
        else
        {
            toggleIsOn = 0;
            settingsGroup.DOMove(new Vector2(0, -522), 1f);
        }
    }
}
