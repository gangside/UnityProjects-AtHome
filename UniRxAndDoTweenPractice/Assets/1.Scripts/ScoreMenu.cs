using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;
using DG.Tweening;

public class ScoreMenu : MonoBehaviour
{
    public RectTransform menu;
    public RectTransform[] buttons;
    public Image[] stars;

    public Color starHighlightColor;
    public float buttonTargetHeight;

    public float pulseStarDelayTime = 1.5f;
    public float moveButtonsDownDelayTime = 2.5f;
    public float menuMoveDisplayTime = 2;

    public float starHighlightTime = 0.5f;
    public float moveButtonTime = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        menu.anchoredPosition = new Vector2(0, -Screen.height * 0.75f);

        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].anchoredPosition = new Vector2(buttons[i].anchoredPosition.x, 50);
        }

        Observable.Timer(TimeSpan.FromSeconds(pulseStarDelayTime))
            .Subscribe(_ => PulseStars());

        Observable.Timer(TimeSpan.FromSeconds(moveButtonsDownDelayTime))
            .Subscribe(_ => moveButtonsDown());

        var moveTween = menu.DOAnchorPosY(0, menuMoveDisplayTime);
        moveTween.SetEase(Ease.OutBounce);
    }

    private void moveButtonsDown() {
        for (int i = 0; i < buttons.Length; i++) {
            var tween = buttons[i].DOAnchorPos(new Vector2(buttons[i].anchoredPosition.x, buttonTargetHeight), moveButtonTime);
            tween.SetEase(Ease.InOutQuint);
        }
    }

    private void PulseStars() {
        for (int i = 0; i < stars.Length; i++) {
            var star = stars[i];

            Observable.Timer(TimeSpan.FromSeconds(0.25f * i))
                .Subscribe(_ =>
                {
                    star.rectTransform.DOPunchScale(new Vector3(0.75f, 0.75f, 0.75f), 0.5f);
                    star.DOColor(starHighlightColor, starHighlightTime);

                    Observable.Timer(TimeSpan.FromSeconds(0.55f)).Subscribe(r =>
                    {
                        var starRotationTween = star.transform.DOPunchScale(new Vector3(0.15f, 0.15f, 0.15f), 2, 1, 40);
                        starRotationTween.SetEase(Ease.Linear);
                        starRotationTween.SetLoops(int.MaxValue, LoopType.Yoyo);
                    });
                });
        }
    }
}
