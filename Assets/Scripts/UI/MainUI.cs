using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] private Text _collisionsText;
    [SerializeField] private Text _timerText;
    [SerializeField] private Button _resetButton;

    private DataContainer _dataContainer;

    public void Constr(DataContainer dataContainer)
    {
        _dataContainer = dataContainer;

        SetButtonListener();
    }

    private void OnEnable()
    {
        SetButtonListener();
    }

    private void OnDisable()
    {
        _resetButton.onClick.RemoveAllListeners();
    }

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        _collisionsText.text = _dataContainer.Collisions.ToString();
        _timerText.text = _dataContainer.Time.ToString();
    }

    private void SetButtonListener()
    {
        _resetButton.onClick.RemoveAllListeners();
        _resetButton.onClick.AddListener(() => _dataContainer.Reset());
    }
}
