using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageSwitch : MonoBehaviour
{
    public GameObject image;
    public GameObject imagePlaceholder;
    public Image imageComponent;

    private void Awake()
    {
        image = GameObject.FindGameObjectWithTag("Image");
        imagePlaceholder = GameObject.FindGameObjectWithTag("Image Placeholder");
        Component[] components = image.GetComponents(typeof(Component));
        foreach (Component component in components)
        {
             Debug.Log(component.GetType());
            if (component.GetType() == typeof(UnityEngine.UI.Image))
            {
               
                imageComponent = component as Image;
            }
        }
        
       // imageComponent = image.GetComponent<Image>();
        Debug.Log(imageComponent);
    }

    private void Start()
    {

    }

    public void ifCorrectAns()
    {
        imageComponent.enabled = true;
        imagePlaceholder.SetActive(false);
        StartCoroutine(imageWait());
    }

    private IEnumerator imageWait()
    {
        yield return new WaitForSeconds(3);
        imageComponent.enabled = false;
    }
}
