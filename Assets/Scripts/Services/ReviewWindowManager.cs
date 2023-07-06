// using Google.Play.Review;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace RunShooter.UI
{
    [RequireComponent(typeof(Button))]
    public class ReviewWindowManager : MonoBehaviour
    {
        //private ReviewManager _manager = new ReviewManager();
        //private PlayReviewInfo _reviewInfo;

        //private Button _button;

        //private void Start()
        //{
        //    _button = GetComponent<Button>();
        //    _button.onClick.AddListener(OnShow);
        //}

        //private void OnEnable()
        //{
        //    StartCoroutine(RequestFlowRoutine());
        //}

        //private void OnShow()
        //{
        //    StartCoroutine(ShowFlowRoutine());
        //}

        //private IEnumerator RequestFlowRoutine() 
        //{
        //    var requestFlowOperation = _manager.RequestReviewFlow();

        //    yield return requestFlowOperation;

        //    if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        //    {
        //        UnityEngine.Debug.LogError(requestFlowOperation.Error.ToString());
        //        yield break;
        //    }

        //    _reviewInfo = requestFlowOperation.GetResult();
        //}

        //private IEnumerator ShowFlowRoutine()
        //{
        //    var launchFlowOperation = _manager.LaunchReviewFlow(_reviewInfo);

        //    yield return launchFlowOperation;

        //    _reviewInfo = null;

        //    if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        //    {
        //        UnityEngine.Debug.LogError(launchFlowOperation.Error.ToString());
        //        yield break;
        //    }
        //}
    }
}
