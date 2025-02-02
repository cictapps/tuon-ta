using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageSwitch : MonoBehaviour
{
    public GameObject image;
    public GameObject imagePlaceholder;
    public Image imageComponent;

    private void Start()
    {
        image = GameObject.FindGameObjectWithTag("Image");
        imagePlaceholder = GameObject.FindGameObjectWithTag("Image Placeholder");
        imageComponent = image.GetComponent<Image>();
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
