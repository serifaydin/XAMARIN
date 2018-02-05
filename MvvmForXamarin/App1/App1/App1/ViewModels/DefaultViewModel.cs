using App1.Models;
using App1.ProjectManager;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class DefaultViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<User> _userListesi;
        public ObservableCollection<User> UserListesi
        {
            get
            {
                if (_userListesi == null)
                    _userListesi = new ObservableCollection<User>();

                return _userListesi;
            }
            set
            {
                _userListesi = value;
            }
        }

        public DefaultViewModel()
        {
            DefaultManager _defaultManager = DefaultManager.CreateAsSingleton();

            HelloWord = "Hello Xamarin for MVVM";
            _loginCommand = new Command<User>(x =>
            {
                User _insertUser = _defaultManager.LoginAction(UserModel);

                _userListesi.Add(_insertUser);

                UserModel = new User();
            });
            _informationCommand = new Command(informationAction);
            _userDeleteCommand = new Command(UserDeleteAction);
            _userUpdateCommand = new Command(UserUpdateAction);
        }

        private string _helloWord;
        private ICommand _loginCommand;
        private ICommand _informationCommand;
        private ICommand _userDeleteCommand;
        private ICommand _userUpdateCommand;
        private User _userModel;

        public string HelloWord
        {
            get
            {
                return _helloWord;
            }
            set
            {
                _helloWord = value;
                onPropertyChanged();
            }
        }
        public ICommand LoginCommand
        {
            get =>
                _loginCommand;
            set
            {
                if (_loginCommand == null)
                    return;

                _loginCommand = value;
            }
        }
        public ICommand InformationCommand
        {
            get
            {
                return _informationCommand;
            }
            set
            {
                if (_informationCommand == null)
                    return;

                _informationCommand = value;
            }
        }
        public ICommand UserDeleteCommand
        {
            get
            {
                return _userDeleteCommand;
            }
            set
            {
                if (_userDeleteCommand == null)
                    return;

                _userDeleteCommand = value;
            }
        }
        public ICommand UserUpdateCommand
        {
            get
            {
                return _userUpdateCommand;
            }
            set
            {
                if (_userUpdateCommand == null)
                    return;

                _userUpdateCommand = value;
            }
        }

        public User UserModel
        {
            get
            {
                if (_userModel == null)
                    _userModel = new User();

                return _userModel;
            }
            set
            {
                _userModel = value;
                onPropertyChanged();
            }
        }

        public async void informationAction()
        {
            await App.Current.MainPage.DisplayAlert("Message", "Xamarin for MVVM", "OK");
        }

        public async void UserDeleteAction(object item)
        {
            _userListesi.Remove(item as User);
        }

        public async void UserUpdateAction(object item)
        {
            UserModel = item as User;
        }
    }
}