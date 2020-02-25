using Kouzi.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Kouzi.Scripts.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {

        #region Constructor

        public MainVM()
        {
            WindowBorderThickness = new Thickness(1);
        }

        #endregion

        #region Commands



        #region Navigate

        private RelayCommand navigateCommand;
        public RelayCommand NavigateCommand
        {
            get
            {
                return navigateCommand ?? (navigateCommand = new RelayCommand(obj =>
                {
                    new NavigateVM().Navigate(obj.ToString());
                }));
            }
        }

        #endregion

        #region CloseCommand
        public Action CloseAction { get; set; }
        private RelayCommand closeCommand;
        public RelayCommand CloseCommand
        {
            get => closeCommand ?? (closeCommand = new RelayCommand(obj =>
            {
                App.MainPageVM.Save();
                CloseAction(); 
            }));

        }
        #endregion

        #region MaximizeCommand
        private RelayCommand maximizeCommand;
        public RelayCommand MaximizeCommand
        {
            get => maximizeCommand ?? (maximizeCommand = new RelayCommand(obj =>
            {
                if (WindowState == WindowState.Normal)
                {
                    //setting border no style
                    WindowBorderThickness = new Thickness(0);
                    ResizeMode = ResizeMode.NoResize;
                    WindowState = WindowState.Maximized;
                }
                else
                {
                    //setting border to resize with grip
                    WindowBorderThickness = new Thickness(1);
                    ResizeMode = ResizeMode.CanResizeWithGrip;
                    WindowState = WindowState.Normal;
                }
            }));
        }
        #endregion

        #region MinimizeCommand
        private RelayCommand minimizeCommand;
        public RelayCommand MinimizeCommand
        {
            get => minimizeCommand ?? (minimizeCommand = new RelayCommand(obj =>
            {
                WindowState = WindowState.Minimized;
            }));
        }
        #endregion

        #region OpenSideMenuCommand
        private RelayCommand openSideCommand;
        public RelayCommand OpenSideCommand
        {
            get => openSideCommand ?? (openSideCommand = new RelayCommand(obj =>
            {
                CloseMenuVisibility = Visibility.Visible;
                OpenMenuVisibility = Visibility.Collapsed;
                IsMenuClosed = false;
            }));
        }
        #endregion

        #region CloseSideMenuCommand
        private RelayCommand closeSideCommand;
        public RelayCommand CloseSideCommand
        {
            get => closeSideCommand ?? (closeSideCommand = new RelayCommand(obj =>
            {
                CloseMenuVisibility = Visibility.Collapsed;
                OpenMenuVisibility = Visibility.Visible;
                IsMenuClosed = true;
            }));


        }
        #endregion

        #endregion

        #region Properties

        #region IsMenuClosed
        private bool isMenuClosed;
        public bool IsMenuClosed
        {
            get => isMenuClosed;
            set
            {
                isMenuClosed = value;
                OnPropertyChanged("IsMenuClosed");
            }
        }
        #endregion


        #region OpenMenuVisibility
        private Visibility openMenuVisibility = Visibility.Visible;
        public Visibility OpenMenuVisibility
        {
            get => openMenuVisibility;
            set
            {
                openMenuVisibility = value;
                OnPropertyChanged("OpenMenuVisibility");
            }
        }
        #endregion


        #region CloseMenuVisibility
        private Visibility closeMenuVisibility = Visibility.Collapsed;
        public Visibility CloseMenuVisibility
        {
            get => closeMenuVisibility;
            set
            {
                closeMenuVisibility = value;
                OnPropertyChanged("CloseMenuVisibility");
            }
        }
        #endregion

        #region WindowState
        private WindowState windowState;
        public WindowState WindowState
        {
            get => windowState;
            set
            {
                windowState = value;
                OnPropertyChanged("WindowState");
            }
        }
        #endregion

        #region ResizeMode
        private ResizeMode resizeMode = ResizeMode.CanResizeWithGrip;
        public ResizeMode ResizeMode
        {
            get => resizeMode;
            set
            {
                resizeMode = value;
                OnPropertyChanged("ResizeMode");
            }
        }
        #endregion

        #region WindowBorderThickness
        private Thickness windowBorderThickness;
        public Thickness WindowBorderThickness
        {
            get => windowBorderThickness;
            set
            {
                windowBorderThickness = value;
                OnPropertyChanged("WindowBorderThickness");
            }
        }
        #endregion

        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
        #endregion



    }
}
