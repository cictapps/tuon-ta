using System.Collections;
using UnityEngine;

public class imageSwitch : MonoBehaviour
{
    [SerializeField] GameObject image;
    [SerializeField] GameObject imagePlaceholder;

    private void Awake()
    {
        Debug.Log("Image: "+image.name);
        image.SetActive(false);
        //image = GameObject.FindGameObjectWithTag("Image");
        //imagePlaceholder = GameObject.FindGameObjectWithTag("Image Placeholder");
        // Component[] components = image.GetComponents(typeof(Component));
        // foreach (Component component in components)
        // {
        //      Debug.Log(component.GetType());
        //     if (component.GetType() == typeof(UnityEngine.UI.Image))
        //     {
               
        //         imageComponent = component as Image;
        //     }
        // }
        
        //imageComponent = image;
        // Debug.Log("Image: "+imageComponent.name);
    }

    private void Start()
    {

    }

    public void ifCorrectAns()
    {

        image.SetActive(true);
        Debug.Log("Setting active");
        imagePlaceholder.SetActive(false);
        StartCoroutine(imageWait());
    }

    private IEnumerator imageWait()
    {
        yield return new WaitForSeconds(3);
        image.SetActive(false);
    }
}
