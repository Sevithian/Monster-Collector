using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterPanelManager : MonoBehaviour
{
    public MonsterData CurrentPrimary;

    [Header("Monster Panel")]
    public GameObject PreviewSpriteObj;
    public TextMeshProUGUI MonsterName;
    public TextMeshProUGUI MonsterLevel;
    public TextMeshProUGUI MonsterHP;
    public TextMeshProUGUI MonsterMP;
    public TextMeshProUGUI MonsterEXP;
    public Image MonsterHPFill;
    public Image MonsterMPFill;
    public Image MonsterEXPFill;

    public void Start()
    {
        GameManager.Instance.PlayerParty.OnPrimaryMonsterChanged += PrimaryChangedHandler;
        CurrentPrimary = GameManager.Instance.PlayerParty.PrimaryMonster;
        UpdateMonsterValues();
        if (GameManager.Instance.PlayerParty.PrimaryMonster != null)
        {
            InstantiatePreviewMonster();
        }
    }

    private void InstantiatePreviewMonster()
    {
        CurrentPrimary.Species = GameManager.Instance.GetSpeciesByID(CurrentPrimary.SpeciesID);
        var monPrev = Instantiate(CurrentPrimary.Species.SpritePrefab, PreviewSpriteObj.transform);
        monPrev.transform.localPosition = Vector3.zero;
        monPrev.GetComponent<EntitySprite>().enabled = false;
        monPrev.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    private void PrimaryChangedHandler(MonsterData newPrimaryMonster)
    {
        CurrentPrimary = newPrimaryMonster;

        if (PreviewSpriteObj.transform.childCount > 0)
            foreach (Transform child in PreviewSpriteObj.transform)
                Destroy(child.gameObject);

        InstantiatePreviewMonster();
        UpdateMonsterValues();
    }

    private void UpdateMonsterValues()
    {
        MonsterName.text = CurrentPrimary.Name;
        MonsterLevel.text = "Level " + CurrentPrimary.Level.ToString();
        MonsterHP.text = CurrentPrimary.CurrentHP + " / " + CurrentPrimary.CurrentStats.HP;
        MonsterMP.text = CurrentPrimary.CurrentMP + " / " + CurrentPrimary.CurrentStats.MP;
        MonsterHPFill.fillAmount = (float)CurrentPrimary.CurrentHP / CurrentPrimary.CurrentStats.HP;
        MonsterMPFill.fillAmount = (float)CurrentPrimary.CurrentMP / CurrentPrimary.CurrentStats.MP;
    }

    private void OnDestroy()
    {
        GameManager.Instance.PlayerParty.OnPrimaryMonsterChanged -= PrimaryChangedHandler;
    }
}
