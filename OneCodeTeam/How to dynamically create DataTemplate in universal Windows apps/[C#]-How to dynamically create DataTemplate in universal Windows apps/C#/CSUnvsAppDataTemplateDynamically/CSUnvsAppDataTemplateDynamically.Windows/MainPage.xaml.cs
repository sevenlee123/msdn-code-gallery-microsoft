﻿/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cs
 * Project:      CSUnvsAppDataTemplateDynamically.Windows
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to create DataTemplate dynamically.
 *  
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;


namespace CSUnvsAppDataTemplateDynamically
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            List<Book> Books = Book.GetBooks();
            BookGridView.ItemsSource = Books;            

            StringBuilder sb = new StringBuilder();
            sb.Append("<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">");
            sb.Append("<Grid Width=\"200\" Height=\"100\">");
            sb.Append("<StackPanel>");
            sb.Append("<StackPanel Orientation=\"Horizontal\" Margin=\"10,3,0,3\"><TextBlock Text=\"Name:\" Style=\"{StaticResource AppBodyTextStyle}\" Margin=\"0,0,5,0\"/><TextBlock Text=\"{Binding Name}\" Style=\"{StaticResource AppBodyTextStyle}\"/></StackPanel>");
            sb.Append("<StackPanel Orientation=\"Horizontal\" Margin=\"10,3,0,3\"><TextBlock Text=\"Price:\" Style=\"{StaticResource AppBodyTextStyle}\" Margin=\"0,0,5,0\"/><TextBlock Text=\"{Binding Price}\" Style=\"{StaticResource AppBodyTextStyle}\"/></StackPanel>");
            sb.Append("<StackPanel Orientation=\"Horizontal\" Margin=\"10,3,0,3\"><TextBlock Text=\"Author:\" Style=\"{StaticResource AppBodyTextStyle}\" Margin=\"0,0,5,0\"/><TextBlock Text=\"{Binding Author}\" Style=\"{StaticResource AppBodyTextStyle}\"/></StackPanel>");
            sb.Append("</StackPanel>");
            sb.Append("</Grid>");
            sb.Append("</DataTemplate>");

            DataTemplate datatemplate = (DataTemplate)XamlReader.Load(sb.ToString());
            BookGridView.ItemTemplate = datatemplate;
            
        }

        private async void Footer_Click(object sender, RoutedEventArgs e)
        {
            HyperlinkButton hyperlinkButton = sender as HyperlinkButton;
            if (hyperlinkButton != null)
            {
                await Windows.System.Launcher.LaunchUriAsync(new Uri(hyperlinkButton.Tag.ToString()));
            }
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width < 800)
            {
                VisualStateManager.GoToState(this, "MinimalLayout", true);
            }
            else if (e.NewSize.Width < e.NewSize.Height)
            {
                VisualStateManager.GoToState(this, "PortraitLayout", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "DefaultLayout", true);
            }
        }
    }
}
