using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace POC.POC_Utilities
{
    public static class ThemeManager
    {
        public static ResourceDictionary GetThemeResourceDictionary(string theme)
        {
            if (theme != null && theme != string.Empty)
            {
                Assembly assembly = Assembly.LoadFrom("Wpf.Themes 1.1.0.dll");
                string packUri = String.Format(@"/WPF.Themes;component/{0}/Theme.xaml", theme);
                string uri = String.Format("PresentationFramework.Aero;V3.0.0.0;31bf3856ad364e35;component\\themes/aero.normalcolor.xaml", UriKind.Relative);

                return Application.LoadComponent(new Uri(packUri, UriKind.Relative)) as ResourceDictionary;


                //Resources.MergedDictionaries.Add(Application.LoadComponent(uri) as ResourceDictionary); 

            }
            return null;
        }

        public static string[] GetThemes()
        {
            string[] themes = new string[] 
            {       "BubbleCreme","BureauBlack", "BureauBlue","ExpressionDark","ExpressionLight","RainierOrange",
                   "RainierPurple","ShinyBlue","ShinyRed","TwilightBlue","WhistlerBlue", 
                   
            };
            return themes;
        }

        public static void ApplyTheme(this Application app, string theme)
        {
            ResourceDictionary dictionary = ThemeManager.GetThemeResourceDictionary(theme);

            if (dictionary != null)
            {

                app.Resources.MergedDictionaries.Clear();
                app.Resources.MergedDictionaries.Add(dictionary);
            }
        }

        public static void ApplyThemes(this Page control, string theme)
        {
            ResourceDictionary dictionary = ThemeManager.GetThemeResourceDictionary(theme);

            if (dictionary != null)
            {
                control.Resources.MergedDictionaries.Clear();
                control.Resources.MergedDictionaries.Add(dictionary);
            }
        }

        public static void ApplyThemesForWindow(this Window control, string theme)
        {
            ResourceDictionary dictionary = ThemeManager.GetThemeResourceDictionary(theme);

            if (dictionary != null)
            {
                control.Resources.MergedDictionaries.Clear();
                control.Resources.MergedDictionaries.Add(dictionary);
            }
        }


        #region Theme

        /// <summary>
        /// Theme Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty ThemeProperty =
            DependencyProperty.RegisterAttached("Theme", typeof(string), typeof(ThemeManager),
                new FrameworkPropertyMetadata((string)string.Empty,
                    new PropertyChangedCallback(OnThemeChanged)));

        /// <summary>
        /// Gets the Theme property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static string GetTheme(DependencyObject d)
        {
            return (string)d.GetValue(ThemeProperty);
        }

        /// <summary>
        /// Sets the Theme property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static void SetTheme(DependencyObject d, string value)
        {
            d.SetValue(ThemeProperty, value);
        }

        /// <summary>
        /// Handles changes to the Theme property.
        /// </summary>
        private static void OnThemeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string theme = e.NewValue as string;
            if (theme == string.Empty)
                return;

            Page control1 = d as Page;
            Window wind = d as Window;
            if (control1 != null)
            {
                control1.ApplyThemes(theme);
                wind.ApplyThemesForWindow(theme);
            }
        }

        #endregion



    }
}
