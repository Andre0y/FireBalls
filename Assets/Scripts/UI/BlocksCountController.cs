using TMPro;
using UnityEngine;

public class BlocksCountController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countOfBlocksText;
    [SerializeField] private Tower _tower;
    
    private void OnEnable()
    {
        _tower.towerSizeUpdated += OnTowerSizeUpdated;
    }

    private void OnDisable()
    {
        _tower.towerSizeUpdated -= OnTowerSizeUpdated;
    }

    private void OnTowerSizeUpdated(int towerSize)
    {
        _countOfBlocksText.text = towerSize.ToString();
    }
}
