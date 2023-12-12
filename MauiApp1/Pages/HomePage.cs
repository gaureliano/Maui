using MauiApp1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Pages;
public partial class HomePage : BasePage
{
    public HomePage()
    {

    }

    public override void Build()
    {
        var stackLayout = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        var label = new Label
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Text = "Home"
        };

        stackLayout.Children.Add(label);

        Content = stackLayout;
    }
}

    

 

