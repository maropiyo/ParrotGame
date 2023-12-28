using UnityEngine;
using UnityEngine.UI;

public class InputValidation : MonoBehaviour
{
    public InputField inputField;
    public Button submitButton;

    void Start()
    {
        // InputFieldのonValueChangedに関数を登録
        inputField.onValueChanged.AddListener(OnInputFieldValueChanged);

        // Submitボタンを最初は非活性にする
        submitButton.interactable = IsValidDisplayName(inputField.text);
    }

    void OnInputFieldValueChanged(string newValue)
    {
        // 文字列の長さが2文字以下の場合、Submitボタンを非活性にする
        submitButton.interactable = IsValidDisplayName(newValue);
    }

    /// <summary>
    /// 表示名が3文字以上8文字以下であればtrueを返す。
    /// </summary>
    /// <param name="displayName"></param>
    /// <returns></returns>
    public bool IsValidDisplayName(string displayName)
    {
        return 3 <= displayName.Length && displayName.Length <= 8;
    }
}
