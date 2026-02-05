using UnityEditor.SceneManagement;
using UnityEngine.EventSystems;
using static Stage;

public class UIButtonSkip : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Stage cSStage;

    public override void InputButtonLeft(PointerEventData eventData)
    {
        cSStage.SetState(GameState.GameDep);
    }
}
