using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.ViewModels
{
    public class CharactersViewModel : ViewModelBase, IScreen
    {
        public RoutingState Router { get; } = new RoutingState();
        public ReactiveCommand<Unit, IRoutableViewModel> GoToCharacterSelection 
            => ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new CharacterSelectionViewModel(this)));
        public CharactersViewModel()
        {
            GoToCharacterSelection.Execute();
        }
    }
}
