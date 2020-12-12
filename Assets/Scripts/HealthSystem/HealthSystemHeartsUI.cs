using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystemHeartsUI : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] Sprite[] heartSprites = new Sprite[3];
    [SerializeField] Vector2 imageSize = new Vector2(30, 30);
    [SerializeField] float offset = 50.0f;
    [SerializeField] int colMax = 5;
#pragma warning restore 0649

    HealthSystemHearts healthSystem;
    List<HeartImage> heartImageList;
    float currentHealth;
    int maxFragments;


    void Awake()
    {
        heartImageList = new List<HeartImage>();
    }
    void Start()
    {
        //Test(20);
    }

    void Test(int maxHealth, [Optional] int health)
    {
        HealthSystemHearts healthSystem = new HealthSystemHearts(maxHealth);
        if (health != 0)
        {
            healthSystem.Health = health;
        }
        SetHealthSystemHearts(healthSystem);
    }

    public HealthSystemHearts GetHealthSystemHearts()
    {
        return healthSystem;
    }
    public void SetHealthSystemHearts(HealthSystemHearts healthSystem)
    {
        this.healthSystem = healthSystem;

        AddHeartImages();

        //Register to Events
        healthSystem.OnDamage += HealthSystemHearts_OnDamage;
        healthSystem.OnHeal += HealthSystemHearts_OnHeal;
        healthSystem.OnAddHeart += HealthSystemHearts_OnAddHeart;
        healthSystem.OnRemoveHeart += HealthSystemHearts_OnRemoveHeart;
        healthSystem.OnDead += HealthSystemHearts_OnDead;
    }

    void AddHeartImages()
    {
        List<HealthSystemHearts.Heart> heartsList = healthSystem.GetHeartsList();

        for (int i = heartImageList.Count; i < heartsList.Count; i++)
        {
            HealthSystemHearts.Heart heart = heartsList[i];
            CreateHeartImage().SetHeartFragments(heart.Fragments);
        }
    }
    void RemoveHeartImages()
    {
        List<HealthSystemHearts.Heart> heartsList = healthSystem.GetHeartsList();
        HeartImage heartImage;

        while (heartsList.Count < heartImageList.Count)
        {
            heartImage = heartImageList[heartsList.Count];
            heartImageList.Remove(heartImage);
            Destroy(heartImage.HeartGameObject);

            //Resize background
            Vector2 bg = GetComponent<RectTransform>().sizeDelta;
            if (heartImageList.Count % colMax == 0)
            {
                bg.y -= offset;
            }
            else if (heartImageList.Count < colMax)
            {
                bg.x -= offset;
            }
            GetComponent<RectTransform>().sizeDelta = bg;
        }
    }

    #region HealthSystemHearts Events
    void HealthSystemHearts_OnDamage(object sender, System.EventArgs e)
    {
        Debug.LogWarning("Damage");
        RefreshAllHearts();
    }
    void HealthSystemHearts_OnHeal(object sender, System.EventArgs e)
    {
        Debug.LogWarning("Healing");
        RefreshAllHearts();
    }
    void HealthSystemHearts_OnAddHeart(object sender, System.EventArgs e)
    {
        Debug.LogWarning("Add Heart");
        AddHeartImages();
        RefreshAllHearts();
    }
    void HealthSystemHearts_OnRemoveHeart(object sender, System.EventArgs e)
    {
        Debug.LogWarning("Remove Heart");
        RemoveHeartImages();
        RefreshAllHearts();
    }
    void HealthSystemHearts_OnDead(object sender, System.EventArgs e)
    {
        Debug.LogWarning("Dead");
        PlayerDeath.playerDeath.OnPlayerDeath();
    }
    #endregion

    /// <summary>
    /// Refreshes HeathUI. Call after changes are applied to health.
    /// </summary>
    void RefreshAllHearts()
    {
        Debug.LogWarning("Refresh");

        List<HealthSystemHearts.Heart> heartsList = healthSystem.GetHeartsList();
        for (int i = 0; i < heartImageList.Count; i++)
        {
            HeartImage heartImage = heartImageList[i];
            HealthSystemHearts.Heart heart = heartsList[i];
            heartImage.SetHeartFragments(heart.Fragments);
        }
    }

    /// <summary>
    /// Creates a heart Image, parents it to this gameObject, and adds ref to heartImageList.
    /// </summary>
    /// <returns></returns>
    HeartImage CreateHeartImage()
    {
        GameObject heartGameObject = new GameObject("Heart", typeof(Image));

        //Set as child of this transform
        heartGameObject.transform.SetParent(transform, false);

        //Sizes of sprites
        heartGameObject.GetComponent<RectTransform>().sizeDelta = imageSize;

        //Set Heart sprite
        Image heartImageUI = heartGameObject.GetComponent<Image>();
        heartImageUI.sprite = heartSprites[0];

        //Resize background
        Vector2 bg = GetComponent<RectTransform>().sizeDelta;
        if (heartImageList.Count != 0)
        {
            if (heartImageList.Count % colMax == 0)
            {
                bg.y += offset;
            }
            else if (heartImageList.Count < colMax)
            {
                bg.x += offset;
            }
        }
        GetComponent<RectTransform>().sizeDelta = bg;

        HeartImage heartImage = new HeartImage(this, heartImageUI, heartGameObject);
        heartImageList.Add(heartImage);

        return heartImage;
    }



    /*Class For HeartImage*/
    public class HeartImage
    {
        HealthSystemHeartsUI healthSystem;
        Image heartImage;
        public GameObject HeartGameObject { get; private set; }

        public HeartImage(HealthSystemHeartsUI healthSystem, Image heartImage, GameObject heartGameObject)
        {
            this.healthSystem = healthSystem;
            this.heartImage = heartImage;
            HeartGameObject = heartGameObject;
        }

        public void SetHeartFragments(int fragment)
        {
            heartImage.sprite = healthSystem.heartSprites[fragment];
        }
    }
}





