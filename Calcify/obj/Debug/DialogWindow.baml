   M S B A M L   `   `   `  ????B  >Calcify, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CalcifyCalcify  5   	   7 clr-namespace:Calcify.PropertiesCalcify.Properties  5   	       Calcify.DialogWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Calcify     5   	   7
properties clr-namespace:Calcify.Properties     5   	     ? WindowStyle$  
ToolWindow=?5	   	      modernWindow#??[  6"    ? Title$ DialogWindow??5
   	    ? ShowInTaskbar .  $	??180??64   $	??400??6A   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 30Q?6    J? CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Calcify.DialogWindow
   Esc   Command# Z 5      6E     5   
   -   5           Enter# Z 5      6G     5   
   -   5        	   Space# Z	 5      6G   .??5      ? 
 ? ColumnDefinitions
 5   
   ?? 5      ?? 5      ?? 5       ? RowDefinitions 5   
   ?? 5      $??7* ?6   ?? 5      $??3* ?6   .+?5!   
   ? $??25, 35, 25, 25q?6   $??3??6'   .+?5"      ?? $Q??KDo you want to save your unsaved changes? Any unsaved changes will be lost.??6     modernTextBlock#??[ 6k   $??Center=?6?   $
??Wrap=?6?   $??15(?6?   5#      ?? 5%   
   $??1??6   $??3??6!   ??5&      ?? 5'       ?? 
TargetType" ??6    ?? Triggers 5(      ?? 5)       ?? Binding 6&   ?? !  Calcify.Properties.Settings   Default ?? Source# Z  ?? Path$ DarkMode? ?? Value True6w   .a?5*      ??  ?? Property ? ?? ?? Value ?#26262665   5+      ?? 5,       6&   ?? # Z $ DarkMode?	 False6w   .a?5-      ??  ? ?? ?#F3F3F365   5.      50      52      ?? 53   
   $??Stretch=?6   $??5??62   $??3??6F   $??1??6Z   $	??1.5??6g   $	??Top=?6t   ??54      ?? 55      " ??6    56      ?? 57       6&   ?? # Z $ DarkMode? True6w   .a?58      ??  ? ?? ?#1D1D1D65   59      ?? 5:       6&   ?? # Z $ DarkMode?	 False6w   .a?5;      ??  ? ?? ?#E5E5E565   5<      5>      5@      ?? 5A   
   -   5         ??Name$ 
SaveButton??5A      $
??Save??62   $??1??6A   $??15q?6N     modernAcceptButton#??[ 6Z    J? Effect 5B      3  -System.Windows.Media.Effects.DropShadowEffect  5C         Color$ Black??6#      	Direction$	 320Q?61      ShadowDepth$ 2Q?6A      
BlurRadius$ 5Q?6Q      Opacity$	 0.1Q?6`   5E      ?? 5F   
   -   5        $ NotSaveButton??5F      $??
Don't Save??6:   $??1??6O   $??1??6\   $??15q?6l     modernButton#??[ 6x    5G        5H      $ Black??6#   $	 320Q?61   $ 2Q?6A   $ 5Q?6Q   $	 0.1Q?6`   5J      ?? 5K   
   -   5        $ CancelButton??5K      $??Cancel??66   $??1??6G   $??2??6T   $??15q?6d   #??[ 6p    5L        5M      $ Black??6#   $	 320Q?61   $ 2Q?6A   $ 5Q?6Q   $	 0.1Q?6`   5O      5P      5Q      