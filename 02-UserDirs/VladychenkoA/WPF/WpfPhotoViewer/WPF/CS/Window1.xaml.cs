using System.Windows.Navigation;
using System.Windows.Media;
using System.Diagnostics;
using System;
using System.Windows.Data;
using System.Xml.Linq;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using System.Windows.Controls;
using Microsoft.VisualBasic;
using System.Windows;
using System.Windows.Input;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Documents;

namespace RibbonSample
{
	public partial class Window1
	{
		
		
		private void RibbonCommand_CanExecute(System.Object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}
	}
	
}
