using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public List<GameObject> Backgrounds;
    public List<GameObject> usedBackgrounds = new List<GameObject>();
    public List<GameObject> startingBackgrounds = new List<GameObject>();

    public int startingBackgroundNo = 4;
    public Transform targetPlayer;
    Vector3 levelLimit;

    private float speed = 0.35f;
    private Transform background;
    Vector3 movement;


    void Start()
    {
        background = this.gameObject.transform;
        GameObject startChunk = Instantiate(InitiateBackgrounds(), transform);
        usedBackgrounds.Add(startChunk);
        movement = new Vector3(0, 0, speed);

        for (int i = 0; i < startingBackgroundNo; i++)
        {
            AddBackground();
        }
    }

    void Update()
    {
        int lastIndex = usedBackgrounds.Count - 1;
        levelLimit = new Vector3(usedBackgrounds[lastIndex].transform.position.x, usedBackgrounds[lastIndex].transform.position.y, usedBackgrounds[lastIndex].transform.position.z);
        Vector3 playerPos = new Vector3(targetPlayer.position.x, targetPlayer.position.y, targetPlayer.position.z);

        if (Vector3.Distance(levelLimit, playerPos) < 400)
        {
            AddBackground();
            RemoveBackground();
        }
    }

    private void FixedUpdate()
    {
        background.transform.position += movement;
    }

    void AddBackground()
    {
        GameObject newBackground = Instantiate(BackgroundToSpawn(), transform);

        if (usedBackgrounds.Count > 0)
        {
            int lastIndex = usedBackgrounds.Count - 1;
            GameObject lastModule = usedBackgrounds[lastIndex];
            Vector3 nextPosition = lastModule.transform.Find("EndPos").position;
            newBackground.transform.position = nextPosition;
            Vector3 offset = newBackground.transform.Find("StartPos").localPosition;
            newBackground.transform.position = nextPosition - offset;
        }

        levelLimit = newBackground.transform.Find("EndPos").position;
        usedBackgrounds.Add(newBackground);
    }

    void RemoveBackground()
    {
        if (usedBackgrounds.Count > 3)
        {
            GameObject chunkToDestroy = usedBackgrounds[0];
            Destroy(chunkToDestroy);
            usedBackgrounds.RemoveAt(0);
        }
    }

    private GameObject InitiateBackgrounds()
    {
        GameObject start = startingBackgrounds[0];
        return start;
    }

    private GameObject BackgroundToSpawn()
    {
        GameObject backgroundToSpawn = Backgrounds[0];
        return backgroundToSpawn;
    }
}
