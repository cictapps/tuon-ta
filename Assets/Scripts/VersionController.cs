using UnityEngine;

public class VersionController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI versionText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         versionText.text = "Ver. " + Application.version;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
