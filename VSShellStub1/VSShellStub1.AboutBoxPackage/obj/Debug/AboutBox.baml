   M S B A M L   `   `   `  ����i  eMicrosoft.VisualStudio.Shell.14.0, Version=14.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a�Zclr-namespace:Microsoft.VisualStudio.PlatformUI;assembly=Microsoft.VisualStudio.Shell.14.0!Microsoft.VisualStudio.PlatformUI  5        VSShellStub1.AboutBoxPackage+   %VSShellStub1.AboutBoxPackage.AboutBox   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      kvsuiZclr-namespace:Microsoft.VisualStudio.PlatformUI;assembly=Microsoft.VisualStudio.Shell.14.0     5         AboutDialogStyle#���   5        � WindowStartupLocation$  CenterOwner=�60    � Title 5      ��  �� RelativeSource �� *Self+ �� Mode$ OneTime=� �� Path$ ProductTitle� � 	Resources 5        aboutProvider � XPath � IsAsynchronous,  &System.Windows.Data.DataSourceProvider   IsInitialLoadEnabled	 �� 
TargetType
 �� Property �� Value  DisplayAreaStyle  ParagraphSeparator  LinkLabelStyle  ReadOnlyDescStyle  OkButtonStyle��%%  &	       &	  )    &	 s    '�� �    &	 
    &	 X    &	 �    &	 �    � 5   
   $ ApplicationInfo��60    .   . .��5	      ��<ApplicationInfo xmlns="">
                    <Link x:Uid="moreinfo" Uri="http://www.My Company.com" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">More Info</Link>
                </ApplicationInfo>        5      �� 5   
   "	 �6)   .�5      �� 
 � ��$
 Auto��6'   �� 5      
 � ��$	 500��6&   �� 5      
 �@�ShowInTaskbar .  6.   �� 5      
 �@�
ResizeMode$ NoResize=�6+   �� 5      
 �@�WindowStyle$ SingleBorderWindow=�6,   �� 5      
 �@�SizeToContent$ Height=�6.   5      �� 5   
   "	 ��6)   .�5      �� 
 � ��$ 
10,10,10,5q�6'   5      �� 5   
   "	 ��6   .�5      �� 
 � ��$ 0q�6(   5      �� 5   
   "	 ��6+   .�5      �� 
 � ��$ 0,10,0,0q�6(   5      �� 5    
   .�5!      �� 
 � ��$ 0q�60   �� 5"      
 � ��$ Center=�6:   5#      �� 5$   
   "	 ��6*   .�5%      �� 
 �@��MinLines$ 6��6)   �� 5&      
 �@��MaxLines$ 6��6)   �� 5'      
 �@��
IsReadOnly . 6+   �� 5(      
 �@��TextWrapping$ WrapWithOverflow=�6-   �� 5)      #
 �@��VerticalScrollBarVisibility$ Visible=�6<   5*      �� 5+   
   "	 ��6&   .�5,      �� 
 � ��$ 75��6)   �� 5-      
 � ��$	 0,5q�6'   �� 5.      
 � ��$ Right=�6/   �� 5/      
 �@��	IsDefault . 6*   �� 50      
 �@��IsCancel . 6)   51      52      .��53      �� .+�54   
   �� #��[ 6    � DataContext 55      ��  �� *FindAncestor+ �� AncestorType" �$ OneTime=�.+�56      �� -   5         ��Name$ productName��56      ��57      �� $ OneTime=�$ Product��� 58       �� Orientation$ 
Horizontal=�6   .+�59      �� -   5        $ versionLabel��59      VersionLabel��$��
Version - ��6C   �� 5:      -   5        $ version��5:      ��6)   �� $ OneTime=�$ Version�5;      �� 5<      -   5        $ 	copyright��5<      ��6'   �� $ OneTime=�$ 	Copyright��� 5=      -   5        $ company��5=      ��6%   �� $ OneTime=�$ Company��� 5>      -   5        $ reserved��5>      reserved��$��All Rights Reserved.��67   �� 5?      -   5        $
 info��5?      info��#��[ 6/   $��Product details:��5@      �� 5A      -   5         ��Name$ description��5A      #��[ 5B      ��5A   +   �� $ OneTime=�$ Description�5B      ]� 5C      .+�5D      �� -	   5         ��Name$ okButton��5D      okButton��#��[ 6<   $��OK��5E      �� 5F      -
   5        $ productLink��5F      #��[ 6-   .��5G      �� -   5         ��Name$ 	hyperlink��5G       #��[ 6g   ��63   �� $ OneTime=�$ LinkUri�.�5H   V   .�5I      �� ��6$   �� $ OneTime=�$ LinkText�5J      5K      5L      5M      5N      5O      