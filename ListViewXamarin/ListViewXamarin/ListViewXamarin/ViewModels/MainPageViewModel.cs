using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Syncfusion.DataSource.Extensions;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ListViewXamarin
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        #region Fields

        private ObservableCollection<ToDoItem> toDoList;

        #endregion

        #region Constructor

        public MainPageViewModel()
        {
            this.GenerateSource();
            ItemTappedCommand = new DelegateCommand<object>(OnItemTapped);
        }

        #endregion

        #region Properties

        public DelegateCommand<object> ItemTappedCommand { get; set; }

        public ObservableCollection<ToDoItem> ToDoList
        {
            get { return toDoList; }
            set { this.toDoList = value; }
        }
        #endregion

        #region Methods

        public void GenerateSource()
        {
            ToDoListRepository todoRepository = new ToDoListRepository();
            toDoList = todoRepository.GetToDoList();
        }

        private void OnItemTapped(object obj)
        {
            var args = obj as Syncfusion.ListView.XForms.ItemTappedEventArgs;
            if (args.ItemType == ItemType.GroupHeader)
            {
                var group = args.ItemData as GroupResult;

                foreach(var item in group.Items)
                {
                    this.ToDoList.Remove(item as ToDoItem);
                }
            }
        }
        #endregion

        #region Prism Methods

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        #endregion
    }
}
