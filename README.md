
# Quick setup to try out F# unit testing on OSX

## Install Xamarin and mono

I am using Xamarin 5.10.2 and mono 4.2.2 and OS X El Capital 10.11.3

### Install Xamarin

  https://xamarin.com/download

### Install mono

  http://www.mono-project.com/download/


### Create new solution in Xamarin

Create a new solution - e.g .Net library with F#

### Install NuGet packages in Xamarin

#### Install NUnit version 2.6.4

* Add NUnit 2.6.4 NuGet package

Right click 'Packages' - Choose 'Add package' 

In search field type: 

* __NUnit version:*__ 

Install NUnit 2.6.4 

__version:*__ will list older versions. NUnit 3.x is currently not compatible with Xamarin 5.10.2

#### Install FsUnit 1.3.1.0

* Add FsUnit 1.3.1.0 NuGet package

Right click 'Packages' - Choose 'Add package' 

In search field type: 

* __FsUnit version:*__ 

Install FsUnit 1.3.10

##### Cleanup: Remove Script.fsx and rename Component1.fs

* Remove Script.fsx
* Rename Component1.fs to e.g 'RomanNumeral.fs'
* Add F# code and unit tests in RomanNumeral.fs

### Run tests

Under Xamarin menu 'View' - choose 'Unit testing'

In Unit Tests pane, Click 'Run All'
