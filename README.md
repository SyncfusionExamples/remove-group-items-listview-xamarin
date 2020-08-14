# How to remove group of items from Xamarin.Forms ListView (SfListView)

You can remove all items in the group when tapping on the GroupHeader using Commands in Prism Framework with Xamarin.Forms SfListView.

You can also refer the following article.

https://www.syncfusion.com/kb/11891/how-to-remove-group-of-items-from-xamarin-forms-listview-sflistview

**C#**

TapCommand defined to remove all items from the group using ItemType from ItemTappedEventArgs. You can get the GroupResult from ItemData of the ItemTappedEventArgs. From the GroupResult.Items property, all the group items can be deleted using the remove method.

``` c#
namespace ListViewXamarin
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private ObservableCollection<ToDoItem> toDoList;
 
        public MainPageViewModel()
        {
            this.GenerateSource();
            ItemTappedCommand = new DelegateCommand<object>(OnItemTapped);
        }
 
        public DelegateCommand<object> ItemTappedCommand { get; set; }
 
        public ObservableCollection<ToDoItem> ToDoList
        {
            get { return toDoList; }
            set { this.toDoList = value; }
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
    }
}
```
**XAML**

Bind **ViewModel.ItemTappedCommand** to **SfListView.TapCommand** to remove all items in the group.
```xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:ListViewXamarin"
             xmlns:syncfusion="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms"
             xmlns:data="clr-namespace:Syncfusion.DataSource;assembly=Syncfusion.DataSource.Portable"
             x:Class="ListViewXamarin.MainPage">
 
    <ContentPage.Content>
        <StackLayout>
            <Grid RowSpacing="0">
                <Grid.RowDefinitions>
                    <RowDefinition Height="40" />
                    <RowDefinition Height="*" />
                </Grid.RowDefinitions>
 
                <Grid BackgroundColor="#2196F3">
                    <Label Text="To Do Items" x:Name="headerLabel" TextColor="White" FontAttributes="Bold" VerticalOptions="Center" HorizontalOptions="Center" />
                </Grid>
 
                <syncfusion:SfListView x:Name="listView" Grid.Row="1" ItemSize="60"
                                    BackgroundColor="#FFE8E8EC"
                                    TapCommand="{Binding ItemTappedCommand}"
                                    GroupHeaderSize="50" 
                                    ItemsSource="{Binding ToDoList}"
                                    SelectionMode="None">
                    <syncfusion:SfListView.DataSource>
                        <data:DataSource>
                            <data:DataSource.GroupDescriptors>
                                <data:GroupDescriptor PropertyName="CategoryName" />
                            </data:DataSource.GroupDescriptors>
                        </data:DataSource>
                    </syncfusion:SfListView.DataSource>
 
                    <syncfusion:SfListView.GroupHeaderTemplate>
                        <DataTemplate>
                            <Grid>
                                <Grid.BackgroundColor>
                                    <OnPlatform x:TypeArguments="Color" Android="#eeeeee" iOS="#f7f7f7"/>
                                </Grid.BackgroundColor>
                                <Label Text="{Binding Key}" FontSize="14" TextColor="#333333" FontAttributes="Bold" VerticalOptions="Center" HorizontalOptions="Start" Margin="15,0,0,0" />
                            </Grid>
                        </DataTemplate>
                    </syncfusion:SfListView.GroupHeaderTemplate>
                </syncfusion:SfListView>
            </Grid>
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```
**Output**

![RemoveGroupItems](https://github.com/SyncfusionExamples/remove-group-items-listview-xamarin/blob/master/ScreenShot/RemoveGroupItems.gif)
