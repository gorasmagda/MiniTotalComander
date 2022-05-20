using System;
using System.Windows;
using System.Windows.Controls;


namespace Projekt1MINITC.View
{
    public partial class PanelTC : UserControl
    {
        public PanelTC()
        {
            InitializeComponent();
        }



        // DRIVES_COMBOBOX
        //rejestracja zdarzenia tak, żeby możliwe było jego bindowanie
        //Properties

        public static readonly DependencyProperty DriveComboSourceProperty =
            DependencyProperty.Register(
                nameof(DriveComboSource),
                typeof(object),
                typeof(PanelTC),
                new PropertyMetadata(null));

        public object DriveComboSource
        {
            get { return (object)GetValue(DriveComboSourceProperty); }
            set { SetValue(DriveComboSourceProperty, value); }
        }

        public static readonly DependencyProperty DriveComboSelectionProperty = 
            DependencyProperty.Register(
                nameof(DriveComboSelection),
                typeof(object),
                typeof(PanelTC),
                new PropertyMetadata(null));
                
        public object DriveComboSelection
        {
            get { return (object)GetValue(DriveComboSelectionProperty); }
            set { SetValue(DriveComboSelectionProperty, value); }
        }

        //Events 
        public static readonly RoutedEvent DriveComboBoxEvent =
        EventManager.RegisterRoutedEvent(nameof(DriveComboBox),
                     RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                     typeof(PanelTC));

        public event RoutedEventHandler DriveComboBox
        {
            add { AddHandler(DriveComboBoxEvent, value); }
            remove { RemoveHandler(DriveComboBoxEvent, value); }
        }

        //Raising events

        void RaiseDrive_combobox_DropDownOpened()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(PanelTC.DriveComboBoxEvent);
            RaiseEvent(newEventArgs);
        }
        private void drive_ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            RaiseDrive_combobox_DropDownOpened();
        }


        //PATH TEXTBLOCK
        //rejestracja zdarzenia tak, żeby możliwe było jego bindowanie
        //Properties

        public static readonly DependencyProperty TextPathProperty =
            DependencyProperty.Register(
                nameof(TextPath),
                typeof(string),
                typeof(PanelTC));

        public string TextPath
        {
            get { return (string)GetValue(TextPathProperty); }
            set { SetValue(TextPathProperty, value); }
        }



        //LISTBOX TO DOOOOOOO 

        //Properties
        public static readonly DependencyProperty ListBoxSourceProperty =
            DependencyProperty.Register(
                nameof(ListBoxSource),
                typeof(object),
                typeof(PanelTC),
                new PropertyMetadata(null));

        public object ListBoxSource
        {
            get { return (object)GetValue(ListBoxSourceProperty); }
            set { SetValue(ListBoxSourceProperty, value); }
        }

        public static readonly DependencyProperty ListBoxSelectionProperty =
            DependencyProperty.Register(
                nameof(ListBoxSelection),
                typeof(object),
                typeof(PanelTC),
                new PropertyMetadata(null));

        public object ListBoxSelection
        {
            get { return (object)GetValue(ListBoxSelectionProperty); }
            set { SetValue(ListBoxSelectionProperty, value); }
        }

        //Events 


        private void file_ListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }




    }
}
