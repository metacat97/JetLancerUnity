using UnityEngine;

public class MiddleMove : MonoBehaviour
{
    public float animationDuration = 3f; // 애니메이션 진행 시간 (초)
    public float targetWidth = 500f; // 목표 너비

    private RectTransform rectTransform; // UI 이미지의 RectTransform
    private float startTime; // 애니메이션 시작 시간

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // UI 이미지의 RectTransform 컴포넌트 가져오기
        startTime = Time.time; // 애니메이션 시작 시간 기록
    }

    private void Update()
    {
        float elapsedTime = Time.time - startTime; // 경과 시간 계산

        if (elapsedTime <= animationDuration) // 애니메이션 진행 중인 경우
        {
            float normalizedTime = elapsedTime / animationDuration; // 정규화된 시간 계산
            float newWidth = Mathf.Lerp(rectTransform.sizeDelta.x, targetWidth, normalizedTime); // 너비 보간 계산
            rectTransform.sizeDelta = new Vector2(newWidth, rectTransform.sizeDelta.y); // 이미지 크기 업데이트
        }
        else // 애니메이션이 완료된 경우
        {
            rectTransform.sizeDelta = new Vector2(targetWidth, rectTransform.sizeDelta.y); // 목표 너비로 크기 조정
            enabled = false; // Update 함수 비활성화하여 추가 연산 방지
        }
    }
}