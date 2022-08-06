
using LogicSimEngine.Interfaces;
using UniRx;
using UnityEngine.UI;

public static class UGUIExtentions
{
    public static void BindCommand(this Toggle self, ICommand command)
    {
        Observable.EveryUpdate().Subscribe(_ => self.interactable = command.CanExecute()).AddTo(self.gameObject);
        self.OnValueChangedAsObservable().Where(isOn=>isOn).Subscribe(_ => command.Execute()).AddTo(self.gameObject);
    }
}
