using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AppearSpaceships : MonoBehaviour
{
    [SerializeField] private GameObject spacheship;
    [SerializeField] private Sprite[] spaceshipSprite;
    [SerializeField] private Transform spaceshipsContainer;

    void Start()
    {
        Instantiate(spacheship, spaceshipsContainer);
        Vector2 newPos = spacheship.transform.position;
        newPos.x = Screen.currentResolution.width * (Random.Range(0, 2) * 2 - 1);
        spacheship.transform.position = newPos;
        spacheship.GetComponent<Image>().sprite = spaceshipSprite[Random.Range(0, 2)];
        StartCoroutine(AppearSpacheshipCoroutine());
    }

    IEnumerator AppearSpacheshipCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(12);
            Instantiate(spacheship, spaceshipsContainer);
            Vector2 newPos = spacheship.transform.position;
            newPos.x = Screen.currentResolution.width * (Random.Range(0, 2) * 2 - 1);
            spacheship.transform.position = newPos;
            spacheship.GetComponent<Image>().sprite = spaceshipSprite[Random.Range(0, 2)];
        }
    }
}
