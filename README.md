
Install Xamarin - https://xamarin.com/download
Install mono - http://www.mono-project.com/download/

I am using Xamarin 5.10.2 and mono 4.2.2 and OS X El Capital 10.11.3

Create a new solution - e.g .Net library with F#

Install nunit version 2.6.4

Add NUnit 2.6.4 NuGet package

Right click 'Packages' - Choose 'Add package' 
In search field type: NUnit version:*

Choose NUnit 2.6.4 and 

Add FsUnit 1.3.1.0 NuGet package

Right click 'Packages' - Choose 'Add package' 
FsUnit version:*

Remove Script.fsx

Rename Component1.fs to e.g 'RomanNumeral.fs'

Add code and tests

Under meny 'View' - choose 'Unit testing'

In Unit Tests pane, Click Run All
