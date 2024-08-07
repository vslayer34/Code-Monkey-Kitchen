using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_DeliveryResults : MonoBehaviour
{
    [Header("Background Image Properties")]
    [SerializeField, Tooltip("Referecne to the background image")]
    private Image _backgroundImage;

    [SerializeField, Tooltip("Referecne to the background image")]
    private Color _successColor;

    [SerializeField, Tooltip("Referecne to the background image")]
    private Color _failColor;


    [Header("Message Properties")]
    [SerializeField, Tooltip("Reference to the message text component")]
    private TextMeshProUGUI _messageText;

    [SerializeField, Tooltip("Success message"), TextArea(2, 3)]
    private string _successMessage;

    [SerializeField, Tooltip("Fail message"), TextArea(2, 3)]
    private string _failMessage;


    [Header("Icon Properties")]
    [SerializeField, Tooltip("Reference to the icon image component")]
    private Image _iconImage;

    [SerializeField, Tooltip("Success icon")]
    private Sprite _successIcon;

    [SerializeField, Tooltip("Fail icon")]
    private Sprite _failIcon;


    private Animator _animator;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    private void Start()
    {
        DeliveryManager.Instance.OnOrderDelivered += DeliveryManager_OnOrderDelivered;
        DeliveryManager.Instance.OnOrderRejected += DeliveryManager_OnOrderRejected;

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        DeliveryManager.Instance.OnOrderDelivered -= DeliveryManager_OnOrderDelivered;
        DeliveryManager.Instance.OnOrderRejected -= DeliveryManager_OnOrderRejected;
    }

    // Signal Methods------------------------------------------------------------------------------
    
    private void DeliveryManager_OnOrderDelivered(object sender, EventArgs e)
    {
        Debug.Log("Called");
        gameObject.SetActive(true);
        _animator.SetTrigger(AnimationParameters.GameUI.UI_DELIVERY_RESULT_PPO_OUT);

        _backgroundImage.color = _successColor;
        _messageText.text = _successMessage;
        _iconImage.sprite = _successIcon;
    }

    private void DeliveryManager_OnOrderRejected(object sender, EventArgs e)
    {
        gameObject.SetActive(true);
        _animator.SetTrigger(AnimationParameters.GameUI.UI_DELIVERY_RESULT_PPO_OUT);

        _backgroundImage.color = _failColor;
        _messageText.text = _failMessage;
        _iconImage.sprite = _failIcon;
    }
}
