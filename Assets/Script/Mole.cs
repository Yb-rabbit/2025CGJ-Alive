using UnityEngine;
using UnityEngine.Audio;

public class Mole : MonoBehaviour
{
    private Hit_Mouse_N gameManager;
    public bool isGood = true; // true: �õ���, false: ������
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
                gameManager.scores_add(-5); // ��õ����5��
            else
                gameManager.scores_add(10); // �򻵵����10��

            gameManager.RemoveMole(gameObject); // �ؼ����Ƴ��Լ�
            Destroy(gameObject); // ���к���ʧ
        }
    }

    // ��ʱδ��ʱ�ɹ���������
    public void Timeout()
    {
        if (!isHit && gameManager != null)
        {
            if (!isGood)
                gameManager.scores_add(-5); // ������δ�򣬿۷�
            gameManager.RemoveMole(gameObject); // �ؼ����Ƴ��Լ�
            Destroy(gameObject);
        }
    }
}
