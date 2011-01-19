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
	#if _MyType
	
	namespace My
	{
		/// <summary>
		/// Module used to define the properties that are available in the My Namespace for WPF
		/// </summary>
		/// <remarks></remarks>
		[global::Microsoft.VisualBasic.HideModuleName()]sealed class MyWpfExtension
			{
			private static ThreadSafeObjectProvider<global::Microsoft.VisualBasic.Devices.Computer> s_Computer = new ThreadSafeObjectProvider<global::Microsoft.VisualBasic.Devices.Computer>();
			private static ThreadSafeObjectProvider<global::Microsoft.VisualBasic.ApplicationServices.User> s_User = new ThreadSafeObjectProvider<global::Microsoft.VisualBasic.ApplicationServices.User>();
			private static ThreadSafeObjectProvider<MyWindows> s_Windows = new ThreadSafeObjectProvider<MyWindows>();
			private static ThreadSafeObjectProvider<global::Microsoft.VisualBasic.Logging.Log> s_Log = new ThreadSafeObjectProvider<global::Microsoft.VisualBasic.Logging.Log>();
			/// <summary>
			/// Returns the application object for the running application
			/// </summary>
			[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]internal static Application Application
				{
				get
				{
					return ((Application) (global::System.Windows.Application.Current));
				}
			}
			/// <summary>
			/// Returns information about the host computer.
			/// </summary>
			[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]internal static global::Microsoft.VisualBasic.Devices.Computer Computer
				{
				get
				{
					return s_Computer.GetInstance();
				}
			}
			/// <summary>
			/// Returns information for the current user.  If you wish to run the application with the current
			/// Windows user credentials, call My.User.InitializeWithWindowsUser().
			/// </summary>
			[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]internal static global::Microsoft.VisualBasic.ApplicationServices.User User
				{
				get
				{
					return s_User.GetInstance();
				}
			}
			/// <summary>
			/// Returns the application log. The listeners can be configured by the application's configuration file.
			/// </summary>
			[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]internal static global::Microsoft.VisualBasic.Logging.Log Log
				{
				get
				{
					return s_Log.GetInstance();
				}
			}
			
			/// <summary>
			/// Returns the collection of Windows defined in the project.
			/// </summary>
			[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]internal static MyWindows Windows
				{
				[global::System.Diagnostics.DebuggerHidden()] get
					{
					return s_Windows.GetInstance();
				}
			}
			[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)][global::Microsoft.VisualBasic.MyGroupCollection("System.Windows.Window", "Create__Instance__", "Dispose__Instance__", "My.MyWpfExtenstionModule.Windows")]internal sealed class MyWindows
				{
					
				[global::System.Diagnostics.DebuggerHidden()]private static T Create__Instance__<T>(T Instance) where T : global::System.Windows.Window, new()
					{
					if (Instance == null)
					{
						if (s_WindowBeingCreated != null)
						{
							if (s_WindowBeingCreated.ContainsKey(typeof(T)) == true)
							{
								throw (new global::System.InvalidOperationException("The window cannot be accessed via My.Windows from the Window constructor."));
							}
						}
						else
						{
							s_WindowBeingCreated = new global::System.Collections.Hashtable();
						}
						s_WindowBeingCreated.Add(typeof(T), null);
						return new T();
//						s_WindowBeingCreated.Remove(typeof(T));
					}
					else
					{
						return Instance;
					}
				}
				[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1822:MarkMembersAsStatic")][global::System.Diagnostics.DebuggerHidden()]private void Dispose__Instance__<T>(ref T instance) where T : global::System.Windows.Window
					{
					instance = null;
				}
				[global::System.Diagnostics.DebuggerHidden()][global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]public MyWindows()
					{
				}
				[global::System.ThreadStatic()]private static global::System.Collections.Hashtable s_WindowBeingCreated;
				[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]public override bool Equals(object o)
				{
					return base.Equals(o);
				}
				[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]public override int GetHashCode()
				{
					return base.GetHashCode();
				}
				[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1822:MarkMembersAsStatic")][global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]internal global::System.Type GetType()
					{
					return typeof(MyWindows);
				}
				[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]public override string ToString()
				{
					return base.ToString();
				}
			}
		}
	}
	public partial class Application : global::System.Windows.Application
	{
		
		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")][global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]internal global::Microsoft.VisualBasic.ApplicationServices.AssemblyInfo Info
			{
			[global::System.Diagnostics.DebuggerHidden()] get
				{
				return new global::Microsoft.VisualBasic.ApplicationServices.AssemblyInfo(global::System.Reflection.Assembly.GetExecutingAssembly());
			}
		}
	}
	#endif
}
