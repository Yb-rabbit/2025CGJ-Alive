using UnityEngine;

public class Mole : MonoBehaviour
{
    private Hit_Mouse_N gameManager;
    public bool isGood = true; // true: 好地鼠, false: 坏地鼠

    public void Init(Hit_Mouse_N manager, bool good)
    {
        gameManager = manager;
        isGood = good;
    }

    void OnMouseDown()
    {
        if (gameManager != null)
        {
            if (isGood)
                gameManager.scores_add(10); // 打好地鼠加10分
            else
                gameManager.scores_add(-5); // 打坏地鼠扣5分

            Destroy(gameObject); // 打中后消失
        }
    }
}
