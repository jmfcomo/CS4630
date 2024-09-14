using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    public GameOverCanvas goCanvas;

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

        GameObject canvasGO = GameObject.Find("GameOverCanvas");
        if (canvasGO != null)
        {
            goCanvas = canvasGO.GetComponent<GameOverCanvas>();
        }
    }

    public void AppleMissed()
    {
        if (basketList.Count > 0)
        {
            GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
            foreach (GameObject tempGO in appleArray)
            {
                Destroy(tempGO);
            }

            int basketIndex = basketList.Count - 1;
            GameObject basketGO = basketList[basketIndex];
            basketList.RemoveAt(basketIndex);
            Destroy(basketGO);
        }

        if (basketList.Count == 0)
        {
            goCanvas.GameOver();
        }
    }
}
