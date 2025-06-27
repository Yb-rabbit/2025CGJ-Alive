using UnityEngine;

public class Mole : MonoBehaviour
{
    private Hit_Mouse_N gameManager;
    public bool isGood = true; // true: �õ���, false: ������

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
                gameManager.scores_add(10); // ��õ����10��
            else
                gameManager.scores_add(-5); // �򻵵����5��

            Destroy(gameObject); // ���к���ʧ
        }
    }
}
