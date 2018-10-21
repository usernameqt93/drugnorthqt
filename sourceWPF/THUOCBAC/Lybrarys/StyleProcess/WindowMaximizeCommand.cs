﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace WindowStyle
{
    public class WindowMaximizeCommand :ICommand
    {     

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var window = parameter as Window;

            if (window != null)
            {
                if(window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                }
                else
                {
                    window.MaxWidth = SystemParameters.VirtualScreenWidth;
		  window.MaxHeight = SystemParameters.WorkArea.Height;

		  //window.MaxHeight = SystemParameters.VirtualScreenHeight;
		  //window.MaxHeight = SystemParameters.VirtualScreenHeight-25;


		  //window.MaxHeight = SystemParameters.WorkArea.Height+15;
		  window.WindowState = WindowState.Maximized;                   
                }                
            }
        }
    }
}
