   M S B A M L   `   `   `  ????B  >Calcify, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CalcifyCalcify  5   	   7 clr-namespace:Calcify.PropertiesCalcify.Properties  5   	       Calcify.Settings   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Calcify     5   	   7
properties clr-namespace:Calcify.Properties     5   	     ? 
ResizeMode$  NoResize=?5	   	      modernWindow#??[  5
   	    ? AllowsTransparency .   ? Title$ Settings??5   	   $	??250??6   $	??450??6'   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 30Q?6   .??5      ?  ? RowDefinitions 5   
   ?? 5      $??30 ?6   ?? 5      .+?5   
   ?   modernHeaderFooter#??[ 6    ? ColumnDefinitions 5      ?? 5      ?? 5      $??50 ?6#   .+?5      ?? -   5         ??Name$ closeButton??5   %   $??1??6      IsHitTestVisibleInChrome .   ChromeCloseButton#??[ 6g   ??5      ?? 5      $??15(?6   $	????6*   $??Segoe MDL2 Assets)?6=   $??Center=?6\   $??Center=?6?   5       5!      ?? 5$   
   $??1??6   .??5%      ? $??Center=?6    5&      ?? 5'      ?? 5(       5*      ?? 5+      ?? 5,      ?? 5-      .+?5/      ?? $??Color sheme:??6   $??Right=?6/   $??
0, 0, 5, 0q?6K   $??0??6_   $??0??6l   ?? 50      $??0??6   $??1??6*   $
??5, 6q?6:   .+?51      	? -   5        	 	?Name$	 DarkModeRadioButton??51   "   $
??Dark??6?   
 	? 	GroupName$
 
ColorSheme??6N   	? 52      -   5        $	 LightModeRadioButton??52   "   $??Light??6@   $
 
ColorSheme??6P   $
??0, 5q?6g   	? 53      -   5        $&	  SystemDefinedDarkModeRadioButton??53   "   $??System defined??6L   $
 
ColorSheme??6e   54      ?? 56      $??Decimal places:??6   $??Right=?62   $??
0, 5, 5, 0q?6N   $??1??6b   $??0??6o   ?? 57      -   5        $ LessDecimalsButton??57      $??25??65   $??20??6A     ChromeButton#??[ 6L   $??1??6r   $??1??6?   $??5q?6?   $
??Left=?6?   .??58      ?? $	????6   $??Segoe MDL2 Assets)?6/   $??12(?6N    J? IsHitTestVisible .  $??Center=?6u   $??Center=?6?   59      ?? 5:      -   5         ??Name$ DecimalPlacesTextBox??5:      $
??22.5??68   $??1??6F   $??1??6S   $??25, 5q?6c   ?? 5;      -   5        $ MoreDecimalsButton??5;      $??25??65   $??20??6A   #??[ 6L   $??1??6r   $??1??6?   $??5q?6?   $??Right=?6?   .??5<      ?? $	????6   $??Segoe MDL2 Assets)?6/   $??12(?6N    .  $??Center=?6u   $??Center=?6?   5=      ?? 5?      $??Document Autor:??6   $??Right=?62   $??
0, 5, 5, 0q?6N   $??2??6b   $??0??6o   ?? 5@      -   5        $ DocumentAutorName??5@      $
??22.5??65   $??25, 5q?6C   $??2??6R   $??1??6_   5A      5B      5C      5D      