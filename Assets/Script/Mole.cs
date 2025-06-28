using UnityEngine;
using UnityEngine.Audio;

public class Mole : MonoBehaviour
{
    private Hit_Mouse_N gameManager;
    public bool isGood = true; // true: 好地鼠, false: 坏地鼠
    private bool isHit = false;

    public void Init(Hit_Mouse_N manager, bool good)
    {
        gameManager = manager;
        isGood = good;
    }

    void OnMouseDown()
    {
        if (gameManager != null && !isHit)
        {
            isHit = true;
            if (isGood)
                gameManager.scores_add(-5); // 打好地鼠扣5分
            else
                gameManager.scores_add(10); // 打坏地鼠加10分

            gameManager.RemoveMole(gameObject); // 关键：移除自己
            Destroy(gameObject); // 打中后消失
        }
    }

    // 超时未打时由管理器调用
    public void Timeout()
    {
        if (!isHit && gameManager != null)
        {
            if (!isGood)
                gameManager.scores_add(-5); // 坏地鼠未打，扣分
            gameManager.RemoveMole(gameObject); // 关键：移除自己
            Destroy(gameObject);
        }
    }
}
