using UnityEngine;

public class MiddleMove : MonoBehaviour
{
    public float animationDuration = 3f; // �ִϸ��̼� ���� �ð� (��)
    public float targetWidth = 500f; // ��ǥ �ʺ�

    private RectTransform rectTransform; // UI �̹����� RectTransform
    private float startTime; // �ִϸ��̼� ���� �ð�

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // UI �̹����� RectTransform ������Ʈ ��������
        startTime = Time.time; // �ִϸ��̼� ���� �ð� ���
    }

    private void Update()
    {
        float elapsedTime = Time.time - startTime; // ��� �ð� ���

        if (elapsedTime <= animationDuration) // �ִϸ��̼� ���� ���� ���
        {
            float normalizedTime = elapsedTime / animationDuration; // ����ȭ�� �ð� ���
            float newWidth = Mathf.Lerp(rectTransform.sizeDelta.x, targetWidth, normalizedTime); // �ʺ� ���� ���
            rectTransform.sizeDelta = new Vector2(newWidth, rectTransform.sizeDelta.y); // �̹��� ũ�� ������Ʈ
        }
        else // �ִϸ��̼��� �Ϸ�� ���
        {
            rectTransform.sizeDelta = new Vector2(targetWidth, rectTransform.sizeDelta.y); // ��ǥ �ʺ�� ũ�� ����
            enabled = false; // Update �Լ� ��Ȱ��ȭ�Ͽ� �߰� ���� ����
        }
    }
}