using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    UIManager uiManager;
    
    public enum GAME_STATE
    {
        Play,
        Pose,
        GameClear,
        GameOver,
    }
    public GAME_STATE gameState { get; private set; }

    void Start()
    {
        gameState = GAME_STATE.Play;
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    public void GameClear(Vector3 endPoint)
    {
        gameState = GAME_STATE.GameClear;

        var sequence = DOTween.Sequence();
        sequence.Append(mainCamera.transform.DOMove(endPoint, 1f).SetEase(Ease.Linear))
            .Join(mainCamera.GetComponent<Camera>().DOOrthoSize(0.17f, 1)).OnComplete(() => { uiManager.ToggleResultUIVisibility(true); });
        sequence.Play();
    }

    public void GameOver()
    {
        gameState = GAME_STATE.GameOver;
        mainCamera.transform.DOShakePosition(0.5f, 1f, 15, 2f, false, true).OnComplete(() => { uiManager.ToggleGameOverUIVisibility(true); });
    }
}
