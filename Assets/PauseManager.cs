using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PreviewSpriteObj;

    public void Awake()
    {
        GameManager.Instance.PlayerParty.OnPrimaryMonsterChanged += PrimaryChangedHandler;
        if (GameManager.Instance.PlayerParty.PrimaryMonster != null)
            Instantiate(GameManager.Instance.PlayerParty.PrimaryMonster.Species.SpritePrefab, PreviewSpriteObj.transform);
    }

    private void OnDestroy()
    {
        GameManager.Instance.PlayerParty.OnPrimaryMonsterChanged -= PrimaryChangedHandler;
    }

    private void PrimaryChangedHandler(MonsterData newPrimaryMonster)
    {
        if (PreviewSpriteObj.transform.childCount > 0)
            foreach (Transform child in PreviewSpriteObj.transform)
                Destroy(child.gameObject);

        Instantiate(GameManager.Instance.PlayerParty.PrimaryMonster.Species.SpritePrefab, PreviewSpriteObj.transform);
    }
}
